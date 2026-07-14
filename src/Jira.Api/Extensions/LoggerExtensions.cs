namespace Jira.Api.Extensions;

public static class LoggerExtensions
{
    public static void LogHttpRequest(this ILogger logger, HttpContext context)
    {
        logger.LogInformation("[Request LOGS] : [{TraceId}]\n\tMethod: {Method}\n\tPath: {Path}",
            context.TraceIdentifier,
            context.Request.Method,
            context.Request.Path);
    }

    public static void LogHttpResponse(this ILogger logger, HttpContext context, long elapsedMilliseconds)
    {
        var statusCode = context.Response.StatusCode;

        var logLevel = statusCode switch
        {
            >= 500 => LogLevel.Error,
            >= 400 => LogLevel.Warning,
            _ => LogLevel.Information
        };

        logger.Log(logLevel,
            "[Response LOGS] : [{TraceId}]\n\tStatusCode: {StatusCode}\n\tCompleted in {ElapsedMilliseconds} ms",
            context.TraceIdentifier,
            statusCode,
            elapsedMilliseconds);
    }
}