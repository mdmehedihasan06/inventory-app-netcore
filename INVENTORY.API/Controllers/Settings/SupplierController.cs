using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : BaseController
	{
		private readonly ISupplierService _iSupplierService;
		private readonly ILogger<SupplierController> _logger;
		public SupplierController(ISupplierService iSupplierService, ILogger<SupplierController> logger)
		{
			_iSupplierService = iSupplierService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iSupplierService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iSupplierService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iSupplierService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] SupplierDto dto)
		{
			var response = await _iSupplierService.CreatAsync(dto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] SupplierDto dto)
		{
			var response = await _iSupplierService.UpdateAsync(dto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iSupplierService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
