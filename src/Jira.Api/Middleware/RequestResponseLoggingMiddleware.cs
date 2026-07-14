using System.Diagnostics;
using Jira.Api.Extensions;

namespace Jira.Api.Middleware;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        _logger.LogHttpRequest(context);

        await _next(context);

        stopwatch.Stop();

        _logger.LogHttpResponse(context, stopwatch.ElapsedMilliseconds);
    }
}