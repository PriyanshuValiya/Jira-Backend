using Jira.Application.Workspaces.DTOs;

namespace Jira.Application.Workspaces.Interfaces;

public interface IWorkspaceService
{
    Task<WorkspaceResponse> CreateAsync(Guid ownerId, CreateWorkspaceRequest request);

    Task<IEnumerable<WorkspaceResponse>> GetAllAsync(Guid ownerId);

    Task<WorkspaceResponse> GetByIdAsync(Guid workspaceId, Guid ownerId);

    Task<WorkspaceResponse> UpdateAsync(Guid workspaceId, Guid ownerId, UpdateWorkspaceRequest request);

    Task DeleteAsync(Guid workspaceId, Guid ownerId);
}