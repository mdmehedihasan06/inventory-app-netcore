using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.Repositories;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Infrastructure.Helper
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
		}
	}
}
