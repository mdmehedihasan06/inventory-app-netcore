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
using INVENTORY.Infrastructure.Repositories;
using INVENTORY.Infrastructure.Repositories.Authentication;
using INVENTORY.Infrastructure.Repository.Services;
using INVENTORY.Infrastructure.RepositoryInterfaces;
using INVENTORY.Infrastructure.RepositoryInterfaces.Authentication;
using INVENTORY.Infrastructure.RepositoryInterfaces.Services;
using INVENTORY.Infrastructure.Constant;
using INVENTORY.Infrastructure.RepositoryInterfaces.Settings;
using INVENTORY.Infrastructure.Repositories.Settings;
using INVENTORY.Infrastructure.RepositoryInterfaces.Sales;
using INVENTORY.Infrastructure.Repositories.Sales;

namespace INVENTORY.Infrastructure.Helper
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddAuth(configuration);

			// User Account
			services.AddScoped<ISalesOrderCostRepository, SalesOrderCostRepository>();
			services.AddScoped<ISalesOrderDetailsRepository, SalesOrderDetailsRepository>();
			services.AddScoped<ISalesOrderMasterRepository, SalesOrderMasterRepository>();
			services.AddScoped<IAccountRepository, AccountRepository>();
			services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            // Settings
            services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IAreaRepository, AreaRepository>();
			services.AddScoped<IKamAreaMappingRepository, KamAreaMappingRepository>();
			services.AddScoped<IRegionRepository, RegionRepository>();
			services.AddScoped<ITerritoryRepository, TerritoryRepository>();
			services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
			services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
			services.AddScoped<IProductSubCategoryRepository, ProductSubCategoryRepository>();
			services.AddScoped<IProductModelRepository, ProductModelRepository>();
			services.AddScoped<IUnitOfMeasurementRepository, UnitOfMeasurementRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();

			return services;
		}
		/// <summary>
		/// Register Auth Services
		/// </summary>
		/// <param name="services"></param>
		/// <param name="configuration"></param>
		/// <returns></returns>
		public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
		{
			///<summary>
			/// Jwt Settings
			///</summary>
			var jwtSettings = new JwtSettings();
			configuration.Bind(JwtSettings.SectionName, jwtSettings);
			services.AddSingleton(Options.Create(jwtSettings));
			///<summary>
			/// static messages
			///</summary>
			var staticMessages = new StaticMessages();
			services.AddSingleton(Options.Create(staticMessages));

			services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
			// Add authorization services
			services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminOnly", policy =>
				{
					policy.RequireRole("admin");
				});
				options.AddPolicy("ManagerOnly", policy =>
				{
					policy.RequireRole("manager");
				});
				options.AddPolicy("AdminOrManagerOnly", policy =>
				{
					policy.RequireRole("admin", "manager");
				});
			});

			//for reference https://curity.io/resources/learn/dotnet-openid-connect-website/
			//.AddOpenIdConnect(options =>
			//{
			//	options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

			//	options.Authority = jwtSettings.Authority;
			//	options.ClientId = jwtSettings.Issuer;
			//	options.ClientSecret = jwtSettings.Secret;
			//	options.ResponseType = OpenIdConnectResponseType.Code;
			//	options.ResponseMode = OpenIdConnectResponseMode.Query;
			//	options.GetClaimsFromUserInfoEndpoint = true;

			//	string scopeString = JwtSettings.SectionName;
			//	scopeString.Split(" ", StringSplitOptions.TrimEntries).ToList().ForEach(scope =>
			//	{
			//		options.Scope.Add(scope);
			//	});
			//	options.TokenValidationParameters = new TokenValidationParameters
			//	{
			//		ValidIssuer = options.Authority,
			//		ValidAudience = options.ClientId
			//	};

			//	options.Events.OnRedirectToIdentityProviderForSignOut = (context) =>
			//	{
			//		context.ProtocolMessage.PostLogoutRedirectUri = jwtSettings.PostLogoutRedirectUri;
			//		return Task.CompletedTask;
			//	};

			//	options.SaveTokens = true;

			//});

			services.AddAuthorization();
			return services;
		}
	}
}
