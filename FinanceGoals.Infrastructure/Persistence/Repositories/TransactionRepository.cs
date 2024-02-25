using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceGoals.Infrastructure.Persistence.Repositories;

/// <inheritdoc/>
public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _appDbContext;

    public TransactionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <inheritdoc/>
    public async Task Save(Transaction entity)
    {
        await _appDbContext.Transactions.AddAsync(entity);
    }

    /// <inheritdoc/>
    public async Task<Transaction?> ReadById(Guid id)
    {
        return await _appDbContext.Transactions.SingleOrDefaultAsync(o => o.Id == id);
    }

    /// <inheritdoc/>
    public async Task<List<Transaction>> ReadAll()
    {
        return await _appDbContext.Transactions.ToListAsync();
    }
}