using EmailService.Web.Common;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace EmailService.Web.Middleware.Extensions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        Result<string> result = Result<string>.Fail("Internal server error");

        switch (exception)
        {
            case ValidationException validationException:
                result = Result<string>
                    .Fail($"{validationException.Message} | {string.Join(',', validationException.Errors)}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                break;
        }

        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
