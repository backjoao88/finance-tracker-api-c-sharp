using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Repositories.Contracts;

namespace FinanceGoals.Core.Repositories;

/// <summary>
/// Represents a contract to a goal data access.
/// </summary>
public interface IGoalRepository : IWritableRepository<Goal>, IReadableRepository<Goal>, IReadableAllRepository<Goal>;