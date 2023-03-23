using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.Repositories;
using VAT.Infrastructure.Repositories.Authentication;
using VAT.Infrastructure.Repository.Services;
using VAT.Infrastructure.RepositoryInterfaces;
using VAT.Infrastructure.RepositoryInterfaces.Authentication;
using VAT.Infrastructure.RepositoryInterfaces.Services;

namespace VAT.Infrastructure.Helper
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddAuth(configuration);
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddScoped<IDateTimeProvider, DateTimeProvider>();
			return services;
		}

		public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
		{
			var jwtSettings = new JwtSettings();
			configuration.Bind(JwtSettings.SectionName, jwtSettings);
			services.AddSingleton(Options.Create(jwtSettings));
			services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.Authority = jwtSettings.Authority;
				options.Audience = jwtSettings.Audience;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwtSettings.Issuer,
					ValidAudience = jwtSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
					ClockSkew = TimeSpan.Zero, // set the token lifetime here
				};
			})

			//for reference https://curity.io/resources/learn/dotnet-openid-connect-website/
			.AddOpenIdConnect(options =>
			{
				options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

				options.Authority = jwtSettings.Authority;
				options.ClientId = jwtSettings.Issuer;
				options.ClientSecret = jwtSettings.Secret;
				options.ResponseType = OpenIdConnectResponseType.Code;
				options.ResponseMode = OpenIdConnectResponseMode.Query;
				options.GetClaimsFromUserInfoEndpoint = true;

				string scopeString = JwtSettings.SectionName;
				scopeString.Split(" ", StringSplitOptions.TrimEntries).ToList().ForEach(scope =>
				{
					options.Scope.Add(scope);
				});
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = options.Authority,
					ValidAudience = options.ClientId
				};

				options.Events.OnRedirectToIdentityProviderForSignOut = (context) =>
				{
					context.ProtocolMessage.PostLogoutRedirectUri = jwtSettings.PostLogoutRedirectUri;
					return Task.CompletedTask;
				};

				options.SaveTokens = true;

			});

			services.AddAuthorization();
			return services;
		}
	}
}
