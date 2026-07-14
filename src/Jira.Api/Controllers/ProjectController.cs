using System.Security.Claims;
using Jira.Application.Projects.DTOs;
using Jira.Application.Projects.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jira.Api.Controllers;

[ApiController]
[Route("api/workspaces/{workspaceId:guid}/projects")]
[Authorize]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid workspaceId, CreateProjectRequest request)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var response = await _projectService.CreateAsync(workspaceId, ownerId, request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid workspaceId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var response = await _projectService.GetAllAsync(workspaceId, ownerId);

        return Ok(response);
    }

    [HttpGet("{projectId:guid}")]
    public async Task<IActionResult> GetById(Guid workspaceId, Guid projectId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var response = await _projectService.GetByIdAsync(projectId, workspaceId, ownerId);

        return Ok(response);
    }

    [HttpPut("{projectId:guid}")]
    public async Task<IActionResult> Update(
    Guid workspaceId,
    Guid projectId,
    UpdateProjectRequest request)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        var response = await _projectService.UpdateAsync(
            projectId,
            workspaceId,
            ownerId,
            request);

        return Ok(response);
    }

    [HttpDelete("{projectId:guid}")]
    public async Task<IActionResult> Delete( Guid workspaceId, Guid projectId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userIdClaim, out var ownerId))
        {
            return Unauthorized();
        }

        await _projectService.DeleteAsync(projectId, workspaceId, ownerId);

        return NoContent();
    }
}