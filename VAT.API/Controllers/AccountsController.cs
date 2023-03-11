using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VAT.API.ServiceInterfaces;
using VAT.Domain.Dtos;

namespace VAT.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountService _iAccountService;
        private readonly ILogger<AccountsController> _logger;
        public AccountsController(IAccountService accountService,ILogger<AccountsController> logger) 
		{
			_iAccountService = accountService;
			_logger = logger;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Login(UserDto model)
		{
            _logger.LogInformation("Hello from Accounts Controller!");
            var token = await _iAccountService.LogIn(model);
			return Ok(token);
		}
	}
}
