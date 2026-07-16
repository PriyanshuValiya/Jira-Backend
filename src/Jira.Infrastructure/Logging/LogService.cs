using System.Text.Json;
using Jira.Application.Logging.Interfaces;
using Jira.Application.Logging.Models;

namespace Jira.Infrastructure.Logging;

public class LogService : ILogService
{
    private readonly string _logFilePath = "C:/Users/PValiya/Jira/Logs";

    public async Task<PagedLogResponse> GetLogsAsync(LogQueryRequest request)
    {
        var filePath = Path.Combine(_logFilePath, $"{DateTime.UtcNow:yyyy-MM-dd}.jsonl");

        var lines = await File.ReadAllLinesAsync(filePath);

        var logs = lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => JsonSerializer.Deserialize<RequestLog>(line)!)
            .ToList();

        if (!string.IsNullOrWhiteSpace(request.Level))
        {
            logs = logs
                .Where(log => log.Level.Equals(request.Level))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(request.Method))
        {
            logs = logs
                .Where(log => log.Method.Equals(request.Method))
                .ToList();
        }

        if (request.StatusCode.HasValue)
        {
            logs = logs
                .Where(log => log.StatusCode == request.StatusCode.Value)
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(request.Ip))
        {
            logs = logs
                .Where(log => log.IpAddress.Equals(request.Ip))
                .ToList();
        }

        if (!string.IsNullOrWhiteSpace(request.Path))
        {
            logs = logs
                .Where(log => log.Path.Equals(request.Path))
                .ToList();
        }

        var totalRecords = logs.Count;
        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        var data = logs
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedLogResponse
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Data = data
        };
    }

    public async Task<List<LogGroupByIpResponse>> GroupByIpAsync(int? threshold)
    {
        var filePath = Path.Combine(_logFilePath, $"{DateTime.UtcNow:yyyy-MM-dd}.jsonl");

        var lines = await File.ReadAllLinesAsync(filePath);

        var result = lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => JsonSerializer.Deserialize<RequestLog>(line)!) // ! is called null-forgiving operator, it tells the compiler that the value will not null.
            .GroupBy(log => log.IpAddress)
            .Select(group => new LogGroupByIpResponse
            {
                IpAddress = group.Key,
                TotalRequests = group.Count()
            })
            .ToList();

        if (threshold.HasValue)
        {
            result = result
                .Where(group => group.TotalRequests >= threshold.Value)
                .ToList();
        }

        return result;
    }
}

// 127.0.0.1 - [log1, log2, log3]
// 10.0.0.1 - [log4, log5]