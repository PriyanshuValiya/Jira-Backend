using Jira.Application.Logging.Models;

public class PagedLogResponse
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalRecords { get; set; }

    public int TotalPages { get; set; }

    public List<RequestLog> Data { get; set; } = [];
}