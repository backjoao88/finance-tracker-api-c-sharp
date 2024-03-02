using FinanceGoals.Core.Primitives;

namespace FinanceGoals.Core.Services.Contracts;

/// <summary>
/// Domain service to perform goal-related functionalities.
/// </summary>
public interface IGoalService
{
    /// <summary>
    /// Performs deposit operation in the specified goal and validates the transaction.
    /// </summary>
    /// <returns>A result value</returns>
    public Task<Result> Deposit(Guid idGoal, decimal amount);

    /// <summary>
    /// Performs withdraw operation in the specified goal and validates the transaction.
    /// </summary>
    /// <returns>A result value</returns>
    public Task<Result> Withdraw(Guid idGoal, decimal amount);
}