﻿using INVENTORY.Application.ServiceInterfaces.Common;
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
	public class RegionService: IRegionService
	{
		private readonly IRegionRepository _iRegionRepository;
		private readonly StaticMessages _staticMessages;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IClaimService _claimService;
		public RegionService(
			IRegionRepository iRegionRepository
			, IOptions<StaticMessages> staticMessages
			, IDateTimeProvider dateTimeProvider
			, IHttpContextAccessor httpContextAccessor
			, IClaimService claimService)
		{
			_iRegionRepository = iRegionRepository;
			_staticMessages = staticMessages.Value;
			_dateTimeProvider = dateTimeProvider;
			_httpContextAccessor = httpContextAccessor;
			_claimService = claimService;
		}


		public async Task<ApiResponse> GetAsync()
		{
			var response = await _iRegionRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetByIdAsync(int id)
		{
			var response = await _iRegionRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetForDropdownAsync()
		{
			var response = (await _iRegionRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false));
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}

		public async Task<ApiResponse> CreatAsync(RegionDto dto)
		{
			try
			{
				var region = dto.Adapt<Region>();
				region.CreatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				region.CreatedDate = _dateTimeProvider.UtcNow;
				var response = await _iRegionRepository.AddAsync(region);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataSavedSuccessfully, Data = response };
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<ApiResponse> UpdateAsync(RegionDto dto)
		{
			try
			{
				var customer = dto.Adapt<Region>();
				customer.UpdatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				customer.UpdatedDate = _dateTimeProvider.UtcNow;
				var response = await _iRegionRepository.UpdateAsync(customer);
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
				var product = await _iRegionRepository.GetByIdAsync(id);
				product.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				product.IsDeleted = true;
				product.DeletedBy = 0;
				product.DeletedDate = _dateTimeProvider.UtcNow;
				await _iRegionRepository.DeleteAsync(product);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = null };
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
