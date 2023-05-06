using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductSubCategoryController : ControllerBase
	{
		private readonly IProductSubCategoryService _iProductSubCategoryService;
		private readonly ILogger<ProductSubCategoryController> _logger;
		public ProductSubCategoryController(IProductSubCategoryService iProductSubCategoryService, ILogger<ProductSubCategoryController> logger)
		{
			_iProductSubCategoryService = iProductSubCategoryService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iProductSubCategoryService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iProductSubCategoryService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iProductSubCategoryService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] ProductSubCategoryDto dto)
		{
			var response = await _iProductSubCategoryService.CreatAsync(dto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] ProductSubCategoryDto dto)
		{
			var response = await _iProductSubCategoryService.UpdateAsync(dto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iProductSubCategoryService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
