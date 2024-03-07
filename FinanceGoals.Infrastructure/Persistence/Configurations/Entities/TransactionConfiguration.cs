using FinanceGoals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceGoals.Infrastructure.Persistence.Configurations.Entities;

/// <inheritdoc />
public class TransactionConfiguration : BaseConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);
        builder.ToTable("tbl_Transactions");
        builder.Property(o => o.Quantity).HasPrecision(10, 2).IsRequired();
        builder.Property(o => o.ETransactionType).IsRequired();
    }
}