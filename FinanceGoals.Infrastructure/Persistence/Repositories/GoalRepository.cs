using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceGoals.Infrastructure.Persistence.Repositories;

/// <inheritdoc/>
public class GoalRepository : IGoalRepository
{
    private readonly AppDbContext _appDbContext;

    public GoalRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc/>
    public async Task Save(Goal entity)
    {
        await _appDbContext.Goals.AddAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<Goal?> ReadById(Guid id)
    {
        return await _appDbContext
            .Goals
            .Include(o => o.Transactions)
            .SingleOrDefaultAsync(o => o.Id == id);
    }
    
    /// <inheritdoc/>
    public async Task<List<Goal>> ReadAll()
    {
        return await _appDbContext
            .Goals
            .Include(o => o.Transactions)
            .ToListAsync();
    }
    
    /// <inheritdoc/>
    public async Task AddTransaction(Transaction transaction)
    {
        await _appDbContext
            .Transactions
            .AddAsync(transaction);
    }
    
    /// <inheritdoc/>
    public async Task<List<Transaction>> GetTransactions(Guid idGoal)
    {
        return await _appDbContext
            .Transactions
            .Where(o => o.IdGoal == idGoal)
            .ToListAsync();
    }
}