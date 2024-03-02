using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Repositories.Contracts;

namespace FinanceGoals.Core.Repositories;

/// <summary>
/// Represents a contract to a goal data access.
/// </summary>
public interface IGoalRepository : IWritableRepository<Goal>, IReadableRepository<Goal>, IReadableAllRepository<Goal>, IDeletableRepository<Goal>
{
    /// <summary>
    /// Adds a transaction to the specified goal.
    /// </summary>
    /// <param name="transaction"></param>
    public Task AddTransaction(Transaction transaction);
    /// <summary>
    /// Lists all transactions of a specified goal.
    /// </summary>
    /// <param name="idGoal"></param>
    /// <returns></returns>
    public Task<List<Transaction>> GetTransactions(Guid idGoal);
}