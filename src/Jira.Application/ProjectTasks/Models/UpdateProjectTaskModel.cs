using Jira.Domain.Enums;

namespace Jira.Application.ProjectTasks.Models;

public class UpdateProjectTaskModel
{
    public Guid WorkspaceId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid ProjectTaskId { get; set; }

    public Guid OwnerId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Domain.Enums.TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}