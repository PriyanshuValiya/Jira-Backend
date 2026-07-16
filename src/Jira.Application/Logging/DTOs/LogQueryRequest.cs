public class LogQueryRequest
{
    public string? Level { get; set; }

    public string? Method { get; set; }

    public int? StatusCode { get; set; }

    public string? Ip { get; set; }

    public string? Path { get; set; }

    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 5;
}