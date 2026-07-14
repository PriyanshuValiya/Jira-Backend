using System.Security.Claims;
using Jira.Application.ProjectTasks.DTOs;
using Jira.Application.ProjectTasks.Interfaces;
using Jira.Application.ProjectTasks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jira.Api.Controllers;

[ApiController]
[Route("api/workspaces/{workspaceId:guid}/projects/{projectId:guid}/tasks")]
[Authorize]
public class ProjectTaskController : ControllerBase
{
    private readonly IProjectTaskService _projectTaskService;

    public ProjectTaskController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid workspaceId, Guid projectId, CreateProjectTaskRequest request)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var model = new CreateProjectTaskModel
        {
            WorkspaceId = workspaceId,
            ProjectId = projectId,
            OwnerId = ownerId,
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            AssigneeId = request.AssigneeId,
            DueDate = request.DueDate
        };

        var response = await _projectTaskService.CreateAsync(model);

        return Created(string.Empty, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid workspaceId, Guid projectId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var model = new GetProjectTasksModel
        {
            WorkspaceId = workspaceId,
            ProjectId = projectId,
            OwnerId = ownerId
        };

        var response = await _projectTaskService.GetAllAsync(model);

        return Ok(response);
    }

    [HttpGet("{taskId:guid}")]
    public async Task<IActionResult> GetById(Guid workspaceId, Guid projectId, Guid taskId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var model = new GetProjectTaskByIdModel
        {
            WorkspaceId = workspaceId,
            ProjectId = projectId,
            ProjectTaskId = taskId,
            OwnerId = ownerId
        };

        var response = await _projectTaskService.GetByIdAsync(model);

        return Ok(response);
    }

    [HttpPut("{taskId:guid}")]
    public async Task<IActionResult> Update(Guid workspaceId, Guid projectId, Guid taskId, UpdateProjectTaskRequest request)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var model = new UpdateProjectTaskModel
        {
            WorkspaceId = workspaceId,
            ProjectId = projectId,
            ProjectTaskId = taskId,
            OwnerId = ownerId,
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            Priority = request.Priority,
            DueDate = request.DueDate
        };

        var response = await _projectTaskService.UpdateAsync(model);

        return Ok(response);
    }

    [HttpDelete("{taskId:guid}")]
    public async Task<IActionResult> Delete(Guid workspaceId, Guid projectId, Guid taskId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var model = new DeleteProjectTaskModel
        {
            WorkspaceId = workspaceId,
            ProjectId = projectId,
            ProjectTaskId = taskId,
            OwnerId = ownerId
        };

        await _projectTaskService.DeleteAsync(model);

        return NoContent();
    }
}