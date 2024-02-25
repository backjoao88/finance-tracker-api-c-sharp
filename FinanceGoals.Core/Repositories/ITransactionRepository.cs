using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Repositories.Contracts;

namespace FinanceGoals.Core.Repositories;

/// <summary>
/// Represents a contract to a transaction data access.
/// </summary>
public interface ITransactionRepository : IWritableRepository<Transaction>, IReadableRepository<Transaction>, IReadableAllRepository<Transaction>;