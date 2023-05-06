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
	public class KamAreaMappingService: IKamAreaMappingService
	{
		private readonly IKamAreaMappingRepository _iKamAreaMappingRepository;
		private readonly StaticMessages _staticMessages;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IClaimService _claimService;
		public KamAreaMappingService(
			IKamAreaMappingRepository iKamAreaMappingRepository
			, IOptions<StaticMessages> staticMessages
			, IDateTimeProvider dateTimeProvider
			, IHttpContextAccessor httpContextAccessor
			, IClaimService claimService)
		{
			_iKamAreaMappingRepository = iKamAreaMappingRepository;
			_staticMessages = staticMessages.Value;
			_dateTimeProvider = dateTimeProvider;
			_httpContextAccessor = httpContextAccessor;
			_claimService = claimService;
		}


		public async Task<ApiResponse> GetAsync()
		{
			var response = await _iKamAreaMappingRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetByIdAsync(int id)
		{
			var response = await _iKamAreaMappingRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}
		public async Task<ApiResponse> GetForDropdownAsync()
		{
			var response = (await _iKamAreaMappingRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false));
			return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = _staticMessages.DataList, Data = response };
		}

		public async Task<ApiResponse> CreatAsync(KamAreaMappingDto dto)
		{
			try
			{
				var kamAreaMapping = dto.Adapt<KamAreaMapping>();
				kamAreaMapping.CreatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				kamAreaMapping.CreatedDate = _dateTimeProvider.UtcNow;
				var response = await _iKamAreaMappingRepository.AddAsync(kamAreaMapping);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataSavedSuccessfully, Data = response };
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<ApiResponse> UpdateAsync(KamAreaMappingDto dto)
		{
			try
			{
				var kamAreaMapping = dto.Adapt<KamAreaMapping>();
				kamAreaMapping.UpdatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				kamAreaMapping.UpdatedDate = _dateTimeProvider.UtcNow;
				var response = await _iKamAreaMappingRepository.UpdateAsync(kamAreaMapping);
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
				var kamAreaMapping = await _iKamAreaMappingRepository.GetByIdAsync(id);
				kamAreaMapping.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
				kamAreaMapping.IsDeleted = true;
				kamAreaMapping.DeletedBy = 0;
				kamAreaMapping.DeletedDate = _dateTimeProvider.UtcNow;
				await _iKamAreaMappingRepository.DeleteAsync(kamAreaMapping);
				return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = null };
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
