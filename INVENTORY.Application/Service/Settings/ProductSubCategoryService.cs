using INVENTORY.Application.ServiceInterfaces.Common;
using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Dtos.Settings;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Infrastructure.Constant;
using INVENTORY.Infrastructure.RepositoryInterfaces.Settings;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.Service.Settings
{
	public class ProductSubCategoryService: IProductSubCategoryService
	{
		private readonly IProductSubCategoryRepository _iProductSubCategoryRepository;
		private readonly StaticMessages _staticMessages;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IClaimService _claimService;
		public ProductSubCategoryService(
			IProductSubCategoryRepository productSubCategoryRepository
			, IOptions<StaticMessages> staticMessages
			, IDateTimeProvider dateTimeProvider
			, IHttpContextAccessor httpContextAccessor
			, IClaimService claimService)
		{
			_iProductSubCategoryRepository = productSubCategoryRepository;
			_staticMessages = staticMessages.Value;
			_dateTimeProvider = dateTimeProvider;
			_httpContextAccessor = httpContextAccessor;
			_claimService = claimService;
		}


		public async Task<ApiResponse> GetAsync()
		{
			var response = await _iProductSubCategoryRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetByIdAsync(int id)
		{
			var response = await _iProductSubCategoryRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetForDropdownAsync()
		{
			var response = (await _iProductSubCategoryRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false));
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}

		public async Task<ApiResponse> CreatAsync(ProductSubCategoryDto dto)
		{
			try
			{
				var productSubCategory = dto.Adapt<ProductSubCategory>();
				productSubCategory.CreatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				productSubCategory.CreatedDate = _dateTimeProvider.UtcNow;
				var response = await _iProductSubCategoryRepository.AddAsync(productSubCategory);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataSavedSuccessfully, Data = response };
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<ApiResponse> UpdateAsync(ProductSubCategoryDto dto)
		{
			try
			{
				var productSubCategory = dto.Adapt<ProductSubCategory> ();
				productSubCategory.UpdatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				productSubCategory.UpdatedDate = _dateTimeProvider.UtcNow;
				var response = await _iProductSubCategoryRepository.UpdateAsync(productSubCategory);
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
				var productSubCategory = await _iProductSubCategoryRepository.GetByIdAsync(id);
				productSubCategory.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				productSubCategory.IsDeleted = true;
				productSubCategory.DeletedBy = 0;
				productSubCategory.DeletedDate = _dateTimeProvider.UtcNow;
				await _iProductSubCategoryRepository.DeleteAsync(productSubCategory);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = null };
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
