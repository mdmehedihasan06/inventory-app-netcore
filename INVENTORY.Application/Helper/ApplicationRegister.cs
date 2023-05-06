using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Application.Service.Authentication;
using INVENTORY.Application.ServiceInterfaces.Authentication;
using Serilog;
using Serilog.Events;
using INVENTORY.Application.Service.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Application.Service.Settings;
using INVENTORY.Application.ServiceInterfaces.Common;

namespace INVENTORY.Application.Helper
{
    public static class ApplicationRegister
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
            #region App_Authentication
            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IDataSecurity, DataSecurity>();
            #endregion

            #region Settings
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IKamAreaMappingService, KamAreaMappingService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ITerritoryService, TerritoryService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductBrandService, ProductBrandService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductSubCategoryService, ProductSubCategoryService>();
            services.AddScoped<IProductModelService, ProductModelService>();
            services.AddScoped<IUnitOfMeasurementService, UnitOfMeasurementService>();
            services.AddScoped<ISupplierService, SupplierService>();

			#endregion

			#region common
            services.AddHttpContextAccessor();
            services.AddScoped<IClaimService, ClaimService>();
			#endregion


			return services;
		}
    }
}
