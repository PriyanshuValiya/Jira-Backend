namespace Jira.Application.ProjectTasks.Models;

public class GetProjectTaskByIdModel
{
    public Guid WorkspaceId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid ProjectTaskId { get; set; }

    public Guid OwnerId { get; set; }
}