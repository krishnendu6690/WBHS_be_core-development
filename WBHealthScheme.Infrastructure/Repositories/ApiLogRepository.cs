using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class ApiLogRepository : IApiLogRepository
{
    private readonly string _connectionString;

    public ApiLogRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public async Task LogAsync(ApiLogEntity log)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = @"INSERT INTO WBHS_API_REQUEST_LOG
        (ApiName, Endpoint, HttpMethod, ClientIp, UserAgent, ApiKey,
         RequestQuery, RequestBody, ResponseStatusCode, ResponseBody,
         ResponseTimeMs, IsSuccess, ErrorMessage, CorrelationId)
        VALUES
        (@ApiName, @Endpoint, @HttpMethod, @ClientIp, @UserAgent, @ApiKey,
         @RequestQuery, @RequestBody, @ResponseStatusCode, @ResponseBody,
         @ResponseTimeMs, @IsSuccess, @ErrorMessage, @CorrelationId)";

        await connection.ExecuteAsync(query, log);
    }
}