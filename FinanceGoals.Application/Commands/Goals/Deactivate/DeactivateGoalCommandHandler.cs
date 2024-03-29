﻿using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using FinanceGoals.Core.Repositories;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deactivate;

/// <summary>
/// Represents the <see cref="DeactivateGoalCommand"/> handler.
/// </summary>
public class DeactivateGoalCommandHandler : IRequestHandler<DeactivateGoalCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateGoalCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeactivateGoalCommand request, CancellationToken cancellationToken)
    {
        var goal = await _unitOfWork.GoalRepository.ReadById(request.IdGoal);
        if (goal is null)
        {
            return Result.Fail(DomainErrors.NotFound);
        }
        goal.Deactivate();
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}