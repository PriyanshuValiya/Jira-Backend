using Jira.Application.Authentication.DTOs;

namespace Jira.Application.Authentication.Interfaces;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);

    Task<LoginResponse> LoginAsync(LoginRequest request);

    Task<CurrentUserResponse> GetCurrentUserAsync(Guid userId);
}