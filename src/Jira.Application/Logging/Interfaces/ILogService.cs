namespace Jira.Application.Logging.Interfaces;  

public interface ILogService
{
    Task<PagedLogResponse> GetLogsAsync(LogQueryRequest request);
    Task<List<LogGroupByIpResponse>> GroupByIpAsync(int? threshold);
}