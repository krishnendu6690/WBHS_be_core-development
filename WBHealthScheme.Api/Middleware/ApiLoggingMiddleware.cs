using System.Diagnostics;
using System.Text;
using WBHealthScheme.Application.Interfaces;
using WBHealthScheme.Domain.Entities;

public class ApiLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ApiLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IApiLogRepository repo)
    {
        var watch = Stopwatch.StartNew();

        var request = context.Request;

        // Enable request body reading
        request.EnableBuffering();

        string requestBody = string.Empty;

        if (request.ContentLength != null && request.ContentLength > 0)
        {
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            requestBody = await reader.ReadToEndAsync();
            request.Body.Position = 0;
        }

        var log = new ApiLogEntity
        {
            ApiName = context.GetEndpoint()?.DisplayName ?? "Beneficiary Authentication",
            Endpoint = request.Path,
            HttpMethod = request.Method,
            ClientIp = context.Connection.RemoteIpAddress?.ToString(),
            UserAgent = request.Headers.ContainsKey("User-Agent") ? request.Headers["User-Agent"].ToString() : null,
            ApiKey = request.Headers.ContainsKey("X-API-KEY") ? request.Headers["X-API-KEY"].ToString() : null,
            RequestQuery = request.QueryString.ToString(),
            RequestBody = requestBody,
            CorrelationId = Guid.NewGuid().ToString()
        };

        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            watch.Stop();

            responseBody.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(responseBody).ReadToEndAsync();

            // Limit response size (avoid DB overload)
            if (!string.IsNullOrEmpty(responseText) && responseText.Length > 4000)
            {
                responseText = responseText.Substring(0, 4000);
            }

            log.ResponseBody = responseText;
            log.ResponseStatusCode = context.Response.StatusCode;
            log.ResponseTimeMs = watch.ElapsedMilliseconds;
            log.IsSuccess = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300;

            await repo.LogAsync(log);

            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);

            // Restore original response stream
            context.Response.Body = originalBodyStream;
        }
        catch (Exception ex)
        {
            watch.Stop();

            log.IsSuccess = false;
            log.ErrorMessage = ex.Message;
            log.ResponseStatusCode = 500;
            log.ResponseTimeMs = watch.ElapsedMilliseconds;

            await repo.LogAsync(log);

            // Restore stream even in exception
            context.Response.Body = originalBodyStream;

            throw;
        }
    }
}