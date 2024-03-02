using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core;
using FinanceGoals.Core.Repositories;
using MediatR;

namespace FinanceGoals.Application.Queries.Goals.GetAll;

/// <summary>
/// Represents a <see cref="GetAllGoalsQuery"/> query handler.
/// </summary>
public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, List<GoalViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllGoalsQueryHandler(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<List<GoalViewModel>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
    {
        var goals = await _unitOfWork.GoalRepository.ReadAll();
        var goalsViewModel = goals
            .Select(goal =>
            {
                var transactionsViewModel = goal
                    .Transactions
                    .Select(transaction =>
                        new TransactionViewModel(transaction.Id, transaction.Quantity, transaction.TransactionType))
                    .ToList();
                return new GoalViewModel(goal.Id, goal.Title, goal.TargetAmount, goal.TotalAmount, goal.Start, goal.End, transactionsViewModel);
            })
            .ToList();
        return goalsViewModel;
    }
}