using Jira.Infrastructure.Persistence;
using Jira.Application.Authentication.Interfaces;
using Jira.Application.Workspaces.Interfaces;
using Jira.Application.Projects.Interfaces;
using Jira.Application.ProjectTasks.Interfaces;
using Jira.Infrastructure.Authentication;
using Jira.Infrastructure.Workspaces;
using Jira.Infrastructure.Projects;
using Jira.Infrastructure.ProjectTasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jira.Infrastructure;

public static class DependencyInjection
{
    // IServiceCollection is a list of service registrations.
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // options is the object configures how EF Core should work.
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IWorkspaceService, WorkspaceService>();

        services.AddScoped<IProjectService, ProjectService>();

        services.AddScoped<IProjectTaskService, ProjectTaskService>();

        return services;
    }
}

/*
Scope in dotnet : Singleton, Scoped, Transient
Dependency Inversion Principle : High Level modules should depend on interfaces, not implementations.
*/