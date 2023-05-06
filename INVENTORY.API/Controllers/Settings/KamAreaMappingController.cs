using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class KamAreaMappingController : BaseController
	{
		private readonly IKamAreaMappingService _iKamAreaMappingService;
		private readonly ILogger<KamAreaMappingController> _logger;
		public KamAreaMappingController(IKamAreaMappingService iKamAreaMappingService, ILogger<KamAreaMappingController> logger)
		{
			_iKamAreaMappingService = iKamAreaMappingService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iKamAreaMappingService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iKamAreaMappingService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iKamAreaMappingService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] KamAreaMappingDto dto)
		{
			var response = await _iKamAreaMappingService.CreatAsync(dto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] KamAreaMappingDto dto)
		{
			var response = await _iKamAreaMappingService.UpdateAsync(dto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iKamAreaMappingService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
