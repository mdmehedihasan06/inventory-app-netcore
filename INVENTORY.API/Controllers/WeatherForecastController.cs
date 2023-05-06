using Microsoft.AspNetCore.Mvc;
using INVENTORY.API.Controllers;

namespace VAT_RND_01.Controllers
{
	[Route("[controller]")]
	[ApiVersion("2.0")]
	public class WeatherForecastController : BaseController
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IActionResult Get()
		{
			return Ok(new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			});
		}
	}
}