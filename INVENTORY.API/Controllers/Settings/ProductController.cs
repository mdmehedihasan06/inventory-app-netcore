using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace INVENTORY.API.Controllers.Settings
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ILogger<AccountsController> _logger;
        public ProductController(IProductService productService, ILogger<AccountsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _productService.GetAsync();
            return Ok(response);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _productService.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpGet("GetForDropdown")]
        public async Task<IActionResult> GetForDropdownAsync()
        {
            var response = await _productService.GetForDropdownAsync();
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDto productDto)
        {
            var response = await _productService.CreatAsync(productDto);
            return Ok(response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromForm] ProductDto productDto)
        {
            var response = await _productService.UpdateAsync(productDto);
            return Ok(response);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
