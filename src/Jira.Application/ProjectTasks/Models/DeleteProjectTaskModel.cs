namespace Jira.Application.ProjectTasks.Models;

public class DeleteProjectTaskModel
{
    public Guid WorkspaceId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid ProjectTaskId { get; set; }

    public Guid OwnerId { get; set; }
}