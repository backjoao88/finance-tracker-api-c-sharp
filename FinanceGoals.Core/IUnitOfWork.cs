using FinanceGoals.Core.Repositories;

namespace FinanceGoals.Core;

/// <summary>
/// Represents the unit of work pattern.
/// </summary>
public interface IUnitOfWork
{
    public ITransactionRepository TransactionRepository { get; set; }
    public IGoalRepository GoalRepository { get; set; } 
    /// <summary>
    /// Commits to the database.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}