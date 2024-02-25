using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinanceGoals.Infrastructure.Persistence.Configurations;

/// <summary>
/// Sets up a <see cref="AppDbContextOptions"/>
/// </summary>
public class AppDbContextOptionsSetup : IConfigureOptions<AppDbContextOptions>
{
    private const string DatabaseSectionName = "Database";
    private readonly IConfiguration _configuration;

    public AppDbContextOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(AppDbContextOptions options)
    {
        _configuration.GetSection(DatabaseSectionName).Bind(options);
    }
}