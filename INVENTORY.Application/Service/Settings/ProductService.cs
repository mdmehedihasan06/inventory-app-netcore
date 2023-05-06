using Azure;
using INVENTORY.Application.ServiceInterfaces.Common;
using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Dtos.Settings;
using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Domain.RequestModel;
using INVENTORY.Infrastructure.Constant;
using INVENTORY.Infrastructure.RepositoryInterfaces.Settings;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace INVENTORY.Application.Service.Settings
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly StaticMessages _staticMessages;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClaimService _claimService;
        public ProductService(
            IProductRepository productRepository
            , IOptions<StaticMessages> staticMessages
            , IDateTimeProvider dateTimeProvider
            , IHttpContextAccessor httpContextAccessor
            , IClaimService claimService)
        {
            _productRepository = productRepository;
            _staticMessages = staticMessages.Value;
            _dateTimeProvider = dateTimeProvider;
            _httpContextAccessor = httpContextAccessor;
            _claimService = claimService;
        }
        
        public async Task<ApiResponse> GetAsync()
        {
            //var temp = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            var response = await _productRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
            return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = string.Empty, Data = response };
        }
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            var response = await _productRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = string.Empty, Data = response };
        }
        public async Task<ApiResponse> GetForDropdownAsync()
        {
            var response = (await _productRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false));
            return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = string.Empty, Data = response };
        }

        public async Task<ApiResponse> CreatAsync(ProductDto productDto)
        {
            try
            {
                var response = await _productRepository.AddAsync(productDto.Adapt<Product>());
                return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataSavedSuccessfully, Data = response };
            }
            catch (Exception)
            {
                throw;
            }            
        }
        public async Task<ApiResponse> UpdateAsync(ProductDto productDto)
        {
            try
            {
                var product = productDto.Adapt<Product>();
                product.UpdatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                product.UpdatedDate = _dateTimeProvider.UtcNow;
                var response = await _productRepository.UpdateAsync(product);
                return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = response };
            }
            catch (Exception)
            {
                throw;
            }            
        }
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                product.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                product.IsDeleted = true;
                product.DeletedDate = _dateTimeProvider.UtcNow;
                await _productRepository.DeleteAsync(product);
                return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = null };
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
