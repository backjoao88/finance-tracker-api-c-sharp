using FinanceGoals.Core;
using FinanceGoals.Core.Repositories;

namespace FinanceGoals.Infrastructure.Persistence;

/// <inheritdoc/>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, IGoalRepository goalRepository)
    {
        _appDbContext = appDbContext;
        GoalRepository = goalRepository;
    }
    private readonly AppDbContext _appDbContext;
    public IGoalRepository GoalRepository { get; set; }

    /// <inheritdoc/>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}