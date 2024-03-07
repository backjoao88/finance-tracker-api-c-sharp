using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deactivate;

/// <summary>
/// Deactivated a goal command.
/// </summary>
public class DeactivateGoalCommand : IRequest<Result>
{
    public DeactivateGoalCommand(Guid idGoal)
    {
        IdGoal = idGoal;
    }
    public Guid IdGoal { get; set; }
}