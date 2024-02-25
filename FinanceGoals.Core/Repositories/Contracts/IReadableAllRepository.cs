using FinanceGoals.Core.Primitives;

namespace FinanceGoals.Core.Repositories.Contracts;

/// <summary>
/// Represents a readable all repository contract.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IReadableAllRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Reads all entities
    /// </summary>
    /// <returns></returns>
    public Task<List<TEntity>> ReadAll();
}