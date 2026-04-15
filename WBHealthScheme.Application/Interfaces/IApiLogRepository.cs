public interface IApiLogRepository
{
    Task LogAsync(ApiLogEntity log);
}