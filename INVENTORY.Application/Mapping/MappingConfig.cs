using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Domain.Dtos;
using INVENTORY.Domain.Entities.Account;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Contracts.Request;
using INVENTORY.Domain.Dtos.Settings;

namespace INVENTORY.Application.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Account
            TypeAdapterConfig<User, UserDto>.NewConfig();
            TypeAdapterConfig<UserDto, LoginModel>.NewConfig();

            // Settings
            TypeAdapterConfig<Region, RegionDto>.NewConfig();
            TypeAdapterConfig<Territory, TerritoryDto>.NewConfig();
            TypeAdapterConfig<Area, AreaDto>.NewConfig();
            TypeAdapterConfig<Product, ProductDto>.NewConfig();
            TypeAdapterConfig<Customer, CustomerDto>.NewConfig();
            TypeAdapterConfig<KamAreaMapping, KamAreaMappingDto>.NewConfig();
            TypeAdapterConfig<ProductBrand, ProductBrandDto>.NewConfig();
            TypeAdapterConfig<ProductCategory, ProductCategoryDto>.NewConfig();
            TypeAdapterConfig<ProductModel, ProductModelDto>.NewConfig();
            TypeAdapterConfig<ProductSubCategory, ProductSubCategoryDto>.NewConfig();
            TypeAdapterConfig<Supplier, SupplierDto>.NewConfig();
            TypeAdapterConfig<UnitOfMeasurement, UnitOfMeasurementDto>.NewConfig();

            // Sales
        }
    }
}
