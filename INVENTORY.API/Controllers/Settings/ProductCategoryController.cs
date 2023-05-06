using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductCategoryController : ControllerBase
	{
		private readonly IProductCategoryService _iProductCategoryService;
		private readonly ILogger<ProductCategoryController> _logger;
		public ProductCategoryController(IProductCategoryService iProductCategoryService, ILogger<ProductCategoryController> logger)
		{
			_iProductCategoryService = iProductCategoryService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iProductCategoryService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iProductCategoryService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iProductCategoryService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] ProductCategoryDto dto)
		{
			var response = await _iProductCategoryService.CreatAsync(dto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] ProductCategoryDto dto)
		{
			var response = await _iProductCategoryService.UpdateAsync(dto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iProductCategoryService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
