using FinanceGoals.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceGoals.Infrastructure.Persistence;

/// <summary>
/// Represents a MySQL context.
/// </summary>
public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Goal> Goals { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
}