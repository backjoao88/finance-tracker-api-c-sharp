using FinanceGoals.Core.Services;
using FinanceGoals.Core.Services.Contracts;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceGoals.Application;

/// <summary>
/// Sets up all dependencies from application layer.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidators();
        services.AddMediator();
        services.AddApplicationServices();
        return services;
    }

    private static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
    }
    
    private static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
    }

    private static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGoalService, GoalService>();
    }
}