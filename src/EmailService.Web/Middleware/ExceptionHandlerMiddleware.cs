using EmailService.Web.Common;
using System.Net;

namespace EmailService.Web.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var logger = context.RequestServices.GetService<ILogger<ExceptionHandlerMiddleware>>();
        context.Response.ContentType = "application/json";
        Result<string> result;

        switch (exception)
        {
            case Exception ex:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                result = Result<string>.Fail(ex.Message);
                break;          
            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                result = Result<string>.Fail(exception.Message);
                break;
        }

        return context.Response.WriteAsJsonAsync(result);
    }
}
