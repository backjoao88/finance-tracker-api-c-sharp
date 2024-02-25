using FinanceGoals.Application;
using FinanceGoals.Infrastructure;

namespace FinanceGoals.Api;

/// <summary>
/// Main app entrypoint.
/// </summary>
public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddInfrastructure();
        builder.Services.AddApplication();
        var app = builder.Build();
        app.MapControllers();
        app.Services.RunMigrations();
        app.Run();
    }
}