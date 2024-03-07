using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives;

namespace FinanceGoals.Core.Repositories.Contracts;

/// <summary>
/// Represents a deletable repository contract.
/// </summary>
public interface IDeletableRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Deletes an entity from a repository.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Nothing</returns>
    public Task Delete(Goal entity);
}