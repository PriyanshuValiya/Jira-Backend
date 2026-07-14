using Jira.Domain.Entities;

namespace Jira.Application.Authentication.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAtUtc) GenerateToken(User user);
}