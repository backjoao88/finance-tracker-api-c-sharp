using FinanceGoals.Core.Primitives;

namespace FinanceGoals.Core.Repositories.Contracts;

/// <summary>
/// Represents a writable repository contract.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IWritableRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Save an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task Save(TEntity entity);
}