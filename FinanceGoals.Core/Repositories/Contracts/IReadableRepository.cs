using FinanceGoals.Core.Primitives;

namespace FinanceGoals.Core.Repositories.Contracts;

/// <summary>
/// Represents a readable repository contract.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IReadableRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Read a single entity.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<TEntity?> ReadById(Guid id);
}