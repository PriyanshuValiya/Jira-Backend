using Jira.Domain.Enums;

namespace Jira.Application.ProjectTasks.Models;

public class CreateProjectTaskModel
{
    public Guid WorkspaceId { get; set; }

    public Guid ProjectId { get; set; }

    public Guid OwnerId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskPriority Priority { get; set; }

    public Guid AssigneeId { get; set; } = Guid.Empty;

    public DateTime? DueDate { get; set; }
}