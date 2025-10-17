using CleanTeath.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanTeeth.API.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleException(context, ex);
        }
    }

	private static Task HandleException(HttpContext context, Exception exception)
	{
		context.Response.ContentType = "application/json";
		var result = 
			exception is CustomValidationException cve ? JsonSerializer.Serialize(cve.ValidationErrors) : string.Empty;

		HttpStatusCode httpStatusCode = exception switch
		{
			NotFoundException => HttpStatusCode.NotFound,
			CustomValidationException => HttpStatusCode.BadRequest,
			_ => HttpStatusCode.InternalServerError
        };

		context.Response.StatusCode = (int)httpStatusCode;

		return context.Response.WriteAsync(result);
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
	public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<ErrorHandlingMiddleware>();
	}
}
