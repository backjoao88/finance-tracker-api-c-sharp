namespace FinanceGoals.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents a set of options for db context.
/// </summary>
public class AppDbContextOptions
{
    public string ConnectionString { get; set; } = string.Empty;
}