using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using INVENTORY.Application.ServiceInterfaces.Authentication;
using INVENTORY.Domain.Dtos;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Contracts.Request;
using Mapster;

namespace INVENTORY.API.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
	public class AccountsController : ControllerBase
    {
        private readonly IAccountService _iAccountService;
        private readonly ILogger<AccountsController> _logger;
        public AccountsController(IAccountService accountService, ILogger<AccountsController> logger)
        {
            _iAccountService = accountService;
            _logger = logger;
        }

		[HttpPost("Login"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
		public async Task<ActionResult> Login([FromForm] LoginModel model)
		{
			_logger.LogInformation("Login try by userid: " + model.UserId);
			var result = await _iAccountService.LogIn(model.Adapt<UserDto>());

			return Ok(result);
		}

		[Authorize(Policy = "AdminOnly")]
		[HttpPost("register"), ProducesResponseType(StatusCodes.Status204NoContent), ProducesDefaultResponseType]
		[ApiVersion("2.0")]
		public async Task<ActionResult> Register([FromForm] UserDto userDto)
        {
            _logger.LogInformation("Registering user: "+ userDto.UserId);
            var result = await _iAccountService.Register(userDto);

            return Ok(result);
        }
    }
}
