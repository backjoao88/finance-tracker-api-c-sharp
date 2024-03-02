using FinanceGoals.Core;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Core.Services.Contracts;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deposit;

/// <summary>
/// Represents the <see cref="DepositCommand"/> handler.
/// </summary>
public class DepositCommandHandler : IRequestHandler<DepositCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGoalService _goalService;

    public DepositCommandHandler(IUnitOfWork unitOfWork, IGoalService goalService)
    {
        _unitOfWork = unitOfWork;
        _goalService = goalService;
    }

    public async Task<Result> Handle(DepositCommand request, CancellationToken cancellationToken)
    {
        return await _goalService.Deposit(request.IdGoal, request.Amount);
    }
}