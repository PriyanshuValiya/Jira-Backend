using Jira.Domain.Enums;

namespace Jira.Application.ProjectTasks.DTOs;

public class CreateProjectTaskRequest
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskPriority Priority { get; set; }

    public Guid AssigneeId { get; set; }

    public DateTime? DueDate { get; set; }
}