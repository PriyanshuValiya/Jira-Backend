using Jira.Domain.Enums;

namespace Jira.Application.ProjectTasks.DTOs;

public class UpdateProjectTaskRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Domain.Enums.TaskStatus Status { get; set; }

    public TaskPriority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}