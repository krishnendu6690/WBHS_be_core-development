public class ApiLogEntity
{
    public string ApiName { get; set; }
    public string Endpoint { get; set; }
    public string HttpMethod { get; set; }
    public string ClientIp { get; set; }
    public string UserAgent { get; set; }
    public string ApiKey { get; set; }
    public string RequestQuery { get; set; }
    public string RequestBody { get; set; }
    public int ResponseStatusCode { get; set; }
    public string ResponseBody { get; set; }
    public long ResponseTimeMs { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public string CorrelationId { get; set; }
}