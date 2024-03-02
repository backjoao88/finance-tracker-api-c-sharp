using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Repositories;
using FinanceGoals.Core.Services.Contracts;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Withdraw;

/// <summary>
/// Represents the <see cref="WithdrawCommand"/> handler.
/// </summary>
public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGoalService _goalService;
    
    public WithdrawCommandHandler(IUnitOfWork unitOfWork, IGoalService goalService)
    {
        _unitOfWork = unitOfWork;
        _goalService = goalService;
    }

    public async Task<Result> Handle(WithdrawCommand request, CancellationToken cancellationToken)
    {
        return await _goalService.Withdraw(request.IdGoal, request.Amount);
    }
}