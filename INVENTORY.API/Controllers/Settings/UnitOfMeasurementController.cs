using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class UnitOfMeasurementController : BaseController
	{
		private readonly IUnitOfMeasurementService _iUnitOfMeasurementService;
		private readonly ILogger<UnitOfMeasurementController> _logger;
		public UnitOfMeasurementController(IUnitOfMeasurementService iUnitOfMeasurementService, ILogger<UnitOfMeasurementController> logger)
		{
			_iUnitOfMeasurementService = iUnitOfMeasurementService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iUnitOfMeasurementService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iUnitOfMeasurementService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iUnitOfMeasurementService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] UnitOfMeasurementDto dto)
		{
			var response = await _iUnitOfMeasurementService.CreatAsync(dto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] UnitOfMeasurementDto dto)
		{
			var response = await _iUnitOfMeasurementService.UpdateAsync(dto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iUnitOfMeasurementService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
