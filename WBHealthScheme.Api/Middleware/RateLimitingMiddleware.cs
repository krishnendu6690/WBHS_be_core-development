using Dapper;
using Microsoft.Data.SqlClient;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _connectionString;

    private const int LIMIT = 1000;
    private const int SENSITIVE_LIMIT = 5;
    private const int WINDOW_MINUTES = 1;

    public RateLimitingMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _connectionString = config.GetConnectionString("DefaultConnection")!;
    }

    public async Task Invoke(HttpContext context)
    {
        var apiKey = context.Request.Headers["X-API-KEY"].ToString();
        if (string.IsNullOrEmpty(apiKey))
            apiKey = "ANONYMOUS";

        var now = DateTime.Now;
        var path = context.Request.Path.Value ?? string.Empty;

        // Extract mobile number from path and apply strict limit
        string trackingKey;
        int effectiveLimit;

        if (path.Contains("/beneficiary-auth/mobile/"))
        {
            var mobileNumber = path.Split("/beneficiary-auth/mobile/").Last().Trim('/');
            trackingKey = $"MOBILE:{mobileNumber}";
            effectiveLimit = 5;
        }
        else
        {
            trackingKey = apiKey;
            effectiveLimit = 1000;
        }

        using var connection = new SqlConnection(_connectionString);

        var existing = await connection.QueryFirstOrDefaultAsync<RateLimitRecord>(
            @"SELECT TOP 1 Id, ApiKey, RequestCount, WindowStart, WindowEnd
              FROM WBHS_API_RATE_LIMIT
              WHERE ApiKey = @ApiKey AND WindowEnd >= @Now
              ORDER BY WindowStart DESC",
            new { ApiKey = trackingKey, Now = now });

        if (existing == null)
        {
            await connection.ExecuteAsync(
                @"INSERT INTO WBHS_API_RATE_LIMIT (ApiKey, RequestCount, WindowStart, WindowEnd)
                  VALUES (@ApiKey, 1, @WindowStart, @WindowEnd)",
                new
                {
                    ApiKey = trackingKey,
                    WindowStart = now,
                    WindowEnd = now.AddMinutes(WINDOW_MINUTES)
                });
        }
        else if (existing.RequestCount >= effectiveLimit)
        {
            context.Response.StatusCode = 429;
            await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
            return;
        }
        else
        {
            await connection.ExecuteAsync(
                "UPDATE WBHS_API_RATE_LIMIT SET RequestCount = RequestCount + 1 WHERE Id = @Id",
                new { existing.Id });
        }

        await _next(context);
    }

    private class RateLimitRecord
    {
        public long Id { get; set; }
        public string ApiKey { get; set; } = null!;
        public int RequestCount { get; set; }
        public DateTime WindowStart { get; set; }
        public DateTime WindowEnd { get; set; }
    }
}
