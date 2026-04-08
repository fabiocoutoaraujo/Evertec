using System.Net;
using System.Text.Json;

namespace FCA.API.Middlewares;

public class GlobalExceptionHandlerMiddleware(RequestDelegate _next,
                                              ILogger<GlobalExceptionHandlerMiddleware> _logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
		try
		{
			await _next(httpContext);
		}
		//catch (ProprietarioNotFoundException ex)
		//{
		//	httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
		//	await httpContext.Response.WriteAsJsonAsync(new { error = ex.Message });
		//}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Ocorreu uma exceção não tratada: {Message}", ex.Message);

			httpContext.Response.ContentType = "application/json";
			httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = new
			{
                httpContext.Response.StatusCode,
				Message = "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde!"
			};

			await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
		}
    }
}
