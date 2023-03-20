using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.Constant;
using VAT.Infrastructure.Repositories;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Infrastructure.Helper
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{

            //services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme);
            return services;
		}
    }
}
