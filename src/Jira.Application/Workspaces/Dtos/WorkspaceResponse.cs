namespace Jira.Application.Workspaces.DTOs;

public class WorkspaceResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }
}