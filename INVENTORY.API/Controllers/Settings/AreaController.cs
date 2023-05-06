using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class AreaController : BaseController
	{
		private readonly IAreaService _iAreaService;
		private readonly ILogger<AreaController> _logger;
		public AreaController(IAreaService iAreaService, ILogger<AreaController> logger)
		{
			_iAreaService = iAreaService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iAreaService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iAreaService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iAreaService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] AreaDto areaDto)
		{
			var response = await _iAreaService.CreatAsync(areaDto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] AreaDto areaDto)
		{
			var response = await _iAreaService.UpdateAsync(areaDto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iAreaService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
