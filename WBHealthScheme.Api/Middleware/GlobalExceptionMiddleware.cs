// ==========================================================
// Middleware: GlobalExceptionMiddleware
// Purpose   : Centralized Exception Handling
// Layer     : API
// Standard  : Enterprise Production Ready
// ==========================================================

using System.Net;
using System.Text.Json;
using WBHealthScheme.Application.Exceptions;

namespace WBHealthScheme.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _environment;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    // ======================================================
    // Middleware Entry Point
    // ======================================================
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");

            await HandleExceptionAsync(context, ex);
        }
    }

    // ======================================================
    // Exception Handler Logic
    // ======================================================
    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode;
        object response;

        switch (exception)
        {
            case NotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                response = new
                {
                    success = false,
                    message = exception.Message
                };
                break;

            case BusinessRuleException:
                statusCode = (int)HttpStatusCode.BadRequest;
                response = new
                {
                    success = false,
                    message = exception.Message
                };
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;

                response = new
                {
                    success = false,
                    message = exception.Message,
                    innerException = exception.InnerException?.Message,
                    stackTrace = exception.StackTrace
                };
                break;
        }

        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(response,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        await context.Response.WriteAsync(json);
    }
}