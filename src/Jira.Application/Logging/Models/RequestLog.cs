namespace Jira.Application.Logging.Models;

public class RequestLog
{
    public DateTime Timestamp { get; set; }

    public string TraceId { get; set; } = string.Empty;

    public string Method { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public string IpAddress { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    public long ElapsedMilliseconds { get; set; }

    public string Level { get; set; } = string.Empty;
}