using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Delete;

/// <summary>
/// Represents the <see cref="DeleteGoalCommand"/> handler.
/// </summary>
public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, Result>
{
    private IUnitOfWork _unitOfWork;

    public DeleteGoalCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
    {
        var goal = await _unitOfWork.GoalRepository.ReadById(request.IdGoal);
        if (goal is null)
        {
            return Result.Fail(DomainErrors.NotFound);
        }
        await _unitOfWork.GoalRepository.Delete(goal);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}