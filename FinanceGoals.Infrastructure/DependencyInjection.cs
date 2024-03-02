using FinanceGoals.Core;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Infrastructure.Persistence;
using FinanceGoals.Infrastructure.Persistence.Configurations;
using FinanceGoals.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FinanceGoals.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .ConfigureOptions<AppDbContextOptionsSetup>()
            .AddDbContext<AppDbContext>(((provider, builder) =>
            {
                var options = provider.GetService(typeof(IOptions<AppDbContextOptions>)) as IOptions<AppDbContextOptions>;
                var dbContextOptions = options?.Value;
                if (dbContextOptions is null) return;
                builder.UseMySql(dbContextOptions.ConnectionString, new MySqlServerVersion(new Version(8, 0, 35)));
            }))
            .AddScoped<IUnitOfWork, AppUnitOfWork>()
            .AddScoped<IGoalRepository, GoalRepository>();
        return services;
    }

    public static IServiceProvider RunMigrations(this IServiceProvider provider)
    {
        var scope = provider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        return provider;
    }
}