using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Delete;

/// <summary>
/// Represents a delete goal command.
/// </summary>
public class DeleteGoalCommand : IRequest<Result>
{
    public DeleteGoalCommand(Guid idGoal)
    {
        IdGoal = idGoal;
    }
    public Guid IdGoal { get; set; }
}