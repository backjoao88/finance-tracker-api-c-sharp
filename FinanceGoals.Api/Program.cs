using FinanceGoals.Application;
using FinanceGoals.Infrastructure;
using Microsoft.OpenApi.Models;

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
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc(
                "v1",
                new OpenApiInfo()
                {
                    Contact = new OpenApiContact()
                    {
                        Name = "João",
                        Email = "joao@gmail.com"
                    }
                }
            );
            var xmlFile = Path.Combine(AppContext.BaseDirectory, "FinanceGoals.Api.xml");
            o.IncludeXmlComments(xmlFile);
        });
        var app = builder.Build();
        app.MapControllers();
        app.Services.RunMigrations();
        app.UseSwaggerUI();
        app.UseSwagger();
        app.Run();
    }
}