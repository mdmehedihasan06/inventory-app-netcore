using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Infrastructure.Helper
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			//services.AddScoped<IAuthRepository, AuthRepository>();
			//services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
			//services.AddScoped<IIdentityService, IdentityService>();

			return services;
		}
	}
}
