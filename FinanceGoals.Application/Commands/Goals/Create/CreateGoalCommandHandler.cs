using FinanceGoals.Core;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Create;

/// <summary>
/// Represents the <see cref="CreateGoalCommand"/>
/// </summary>
public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGoalCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        var goal = new Goal(request.Title, request.TargetAmount, request.MonthlySavingAmount, request.Start, request.End);
        await _unitOfWork.GoalRepository.Save(goal);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}