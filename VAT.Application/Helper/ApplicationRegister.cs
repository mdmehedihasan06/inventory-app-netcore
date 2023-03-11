using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.API.ServiceInterfaces;
using VAT.Application.Service;
using VAT.Infrastructure.Repositories;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Application.Helper
{
	public static class ApplicationRegister
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddScoped<IAccountService, AccountService>();

			return services;
		}
	}
}
