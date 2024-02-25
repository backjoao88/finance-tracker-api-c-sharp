using FinanceGoals.Core;
using FinanceGoals.Core.Repositories;

namespace FinanceGoals.Infrastructure.Persistence;

/// <inheritdoc/>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, IGoalRepository goalRepository, ITransactionRepository transactionRepository)
    {
        _appDbContext = appDbContext;
        GoalRepository = goalRepository;
        TransactionRepository = transactionRepository;
    }
    
    private readonly AppDbContext _appDbContext;
    public IGoalRepository GoalRepository { get; set; }
    public ITransactionRepository TransactionRepository { get; set; }

    /// <inheritdoc/>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}