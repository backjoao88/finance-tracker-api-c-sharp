using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Core.Services.Contracts;

namespace FinanceGoals.Core.Services;

/// <inheritdoc/>>
public class GoalService : IGoalService
{
    private readonly IUnitOfWork _unitOfWork;

    public GoalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>>
    public async Task<Result> Deposit(Guid idGoal, decimal amount)
    {
        var goal = await _unitOfWork.GoalRepository.ReadById(idGoal);
        if (goal is null)
        {
            return Result.Fail(DomainErrors.NotFound);
        }
        var transactionResult = goal.Deposit(amount);
        if (transactionResult.IsFailure)
        {
            return transactionResult;
        }
        await _unitOfWork.GoalRepository.AddTransaction(transactionResult.Value);
        await _unitOfWork.Complete();
        return Result.Ok();
    }

    /// <inheritdoc/>>
    public async Task<Result> Withdraw(Guid idGoal, decimal amount)
    {
        var goal = await _unitOfWork.GoalRepository.ReadById(idGoal);
        if (goal is null)
        {
            return Result.Fail(DomainErrors.NotFound);
        }
        var transactionResult = goal.Withdraw(amount);
        if (transactionResult.IsFailure)
        {
            return transactionResult;
        }
        await _unitOfWork.GoalRepository.AddTransaction(transactionResult.Value);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}