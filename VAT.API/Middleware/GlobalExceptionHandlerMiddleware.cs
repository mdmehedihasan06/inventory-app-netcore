using System.Text.Json;
using System.Net;
using System.Web.Http.ExceptionHandling;

namespace VAT.API.Middleware
{
	public class GlobalExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalExceptionHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

        //public async Task Invoke(HttpContext httpContext)
        //{
        //	try
        //	{
        //		await _next(httpContext);
        //	}
        //	catch (Exception ex)
        //	{
        //		await HandleExceptionAsync(httpContext, ex);
        //	}
        //}

        //private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    await context.Response.WriteAsync(JsonSerializer.Serialize(new
        //    {
        //        StatusCode = context.Response.StatusCode,
        //        Message = exception.Message
        //    }.ToString()));
        //}

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);

                // Return a JSON response with the error message
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync(JsonSerializer.Serialize(new { StatusCode = context.Response.StatusCode, ErrorMessage = ex.Message }));
            }
        }		        
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	//public static class GlobalExceptionHandlerMiddlewareExtensions
	//{
	//	public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
	//	{
	//		return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
	//	}
	//}
}

