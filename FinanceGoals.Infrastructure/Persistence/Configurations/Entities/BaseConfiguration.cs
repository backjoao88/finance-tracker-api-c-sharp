using FinanceGoals.Core.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceGoals.Infrastructure.Persistence.Configurations.Entities;

/// <summary>
/// Entity configuration for the database.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(o => o.Id);
    }
}