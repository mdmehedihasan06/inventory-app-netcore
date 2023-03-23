using Microsoft.AspNetCore.Authentication.JwtBearer;
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
			services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
			return services;
		}

		public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
		{
			var jwtSettings = new JwtSettings();
			configuration.Bind(JwtSettings.SectionName, jwtSettings);
			services.AddSingleton(Options.Create(jwtSettings));
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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
				options.Configuration = new OpenIdConnectConfiguration();
			});


			services.AddAuthorization();
			return services;
		}
	}
}
