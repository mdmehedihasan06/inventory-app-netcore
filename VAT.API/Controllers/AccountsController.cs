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
		public AccountsController(IAccountService accountService) 
		{
			_iAccountService = accountService;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Login(LoginModel model)
		{
			var token = await _iAccountService.LogIn(model);
			return Ok(token);
		}
	}
}
