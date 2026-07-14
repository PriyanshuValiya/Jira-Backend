namespace Jira.Application.Workspaces.DTOs;

public class UpdateWorkspaceRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}