﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VAT.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BaseController : ControllerBase
	{
    }
}
