using FinanceGoals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceGoals.Infrastructure.Persistence.Configurations.Entities;

/// <inheritdoc />
public class GoalConfiguration : BaseConfiguration<Goal>
{
    public override void Configure(EntityTypeBuilder<Goal> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Goals");
        builder.Property(o => o.Title).IsRequired();
        builder.Property(o => o.Active).IsRequired();
        builder.Property(o => o.TargetAmount).HasPrecision(10, 2).IsRequired();
        builder.Property(o => o.TotalAmount).HasPrecision(10, 2);
        builder
            .HasMany(o => o.Transactions)
            .WithOne()
            .HasForeignKey(o => o.IdGoal)
            .OnDelete(DeleteBehavior.Restrict);
    }
}