using Microsoft.AspNetCore.Mvc;
using Jira.Application.Logging.Interfaces;

namespace Jira.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs([FromQuery] LogQueryRequest request)
    {
        var response = await _logService.GetLogsAsync(request);

        return Ok(response);
    }

    [HttpGet("ip-group")]
    public async Task<IActionResult> GroupByIp(int? threshold)
    {
        var response = await _logService.GroupByIpAsync(threshold);

        return Ok(response);
    }
}