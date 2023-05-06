using INVENTORY.Application.Service.Settings;
using INVENTORY.Application.ServiceInterfaces.Settings;
using INVENTORY.Domain.Dtos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY.API.Controllers.Settings
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : BaseController
	{
		private readonly ICustomerService _iCustomerService;
		private readonly ILogger<AccountsController> _logger;
		public CustomerController(ICustomerService iCustomerService, ILogger<AccountsController> logger)
		{
			_iCustomerService = iCustomerService;
			_logger = logger;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> GetAsync()
		{
			var response = await _iCustomerService.GetAsync();
			return Ok(response);
		}
		[HttpPost("GetById")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var response = await _iCustomerService.GetByIdAsync(id);
			return Ok(response);
		}
		[HttpGet("GetForDropdown")]
		public async Task<IActionResult> GetForDropdownAsync()
		{
			var response = await _iCustomerService.GetForDropdownAsync();
			return Ok(response);
		}

		[HttpPost("Create")]
		public async Task<IActionResult> CreateAsync([FromForm] CustomerDto customerDto)
		{
			var response = await _iCustomerService.CreatAsync(customerDto);
			return Ok(response);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> UpdateAsync([FromForm] CustomerDto customerDto)
		{
			var response = await _iCustomerService.UpdateAsync(customerDto);
			return Ok(response);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var response = await _iCustomerService.DeleteAsync(id);
			return Ok(response);
		}
	}
}
