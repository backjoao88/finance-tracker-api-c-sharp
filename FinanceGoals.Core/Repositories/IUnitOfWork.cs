namespace FinanceGoals.Core.Repositories;

/// <summary>
/// Represents the unit of work pattern.
/// </summary>
public interface IUnitOfWork
{
    public IGoalRepository GoalRepository { get; set; } 
    /// <summary>
    /// Commits to the database.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}