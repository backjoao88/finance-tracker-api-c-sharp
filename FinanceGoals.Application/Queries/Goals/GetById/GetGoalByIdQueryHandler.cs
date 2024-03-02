using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using MediatR;

namespace FinanceGoals.Application.Queries.Goals.GetById;

/// <summary>
/// Represents the <see cref="GetGoalByIdQuery"/> handler.
/// </summary>
public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, Result<GoalViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGoalByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GoalViewModel>> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var goal = await _unitOfWork
            .GoalRepository
            .ReadById(request.Id);
        if (goal is null)
        {
            return Result.Fail<GoalViewModel>(DomainErrors.NotFound);
        }
        var transactionsViewModel = goal
            .Transactions
            .Select(transaction =>
                new TransactionViewModel(transaction.Id, transaction.Quantity, transaction.ETransactionType))
            .ToList();
        return Result.Ok(new GoalViewModel(goal.Id, goal.Title, goal.TargetAmount, goal.TotalAmount, goal.Start, goal.End, goal.Active, transactionsViewModel));
    }
}