using System.Net;
using System.Web.Http.ExceptionHandling;

namespace VAT.API.Middleware
{
	//public class ExceptionHandler : IExceptionHandler
	//{
	//	private readonly ILogger<ExceptionHandler> _logger;

	//	public ExceptionHandler(ILogger<ExceptionHandler> logger)
	//	{
	//		_logger = logger;
	//	}

	//	public async Task HandleException(HttpContext context, Exception exception)
	//	{
	//		_logger.LogError(exception, "An error occurred while processing the request.");

	//		context.Response.ContentType = "application/json";
	//		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

	//		var response = new
	//		{
	//			message = "An error occurred while processing the request."
	//		};

	//		await context.Response.WriteAsJsonAsync(response);
	//	}
	//}
}
