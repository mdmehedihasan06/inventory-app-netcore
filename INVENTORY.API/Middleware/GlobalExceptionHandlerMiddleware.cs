using System.Text.Json;
using System.Net;
using INVENTORY.Contracts.CustomException;

namespace INVENTORY.API.Middleware
{
	public class GlobalExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (CustomException customException)
			{
				// Create a JSON error response with the custom exception message and status code
				var errorResponse = new
				{
					error = customException.Message,
					status = (int)customException.StatusCode
				};
				var json = JsonSerializer.Serialize(errorResponse);

				// Set the response content type to JSON and the status code to the custom exception's status code
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)customException.StatusCode;

				// Write the error response JSON to the response body
				await context.Response.WriteAsync(json);
			}
			catch (UnauthorizedAccessException)
			{
				context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(JsonSerializer.Serialize(new { message = "Unauthorized" }));
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine(ex);

				// Create a JSON error response for unhandled exceptions
				var errorResponse = new
				{
					error = "An error occurred while processing the request.",
					status = (int)HttpStatusCode.InternalServerError
				};
				var json = JsonSerializer.Serialize(errorResponse);

				// Set the response content type to JSON and the status code to 500
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				// Write the error response JSON to the response body
				await context.Response.WriteAsync(json);
			}
		}
	}


}

