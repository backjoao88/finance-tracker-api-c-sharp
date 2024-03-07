using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Create;

/// <summary>
/// Represents a create goal command.
/// </summary>
public class CreateGoalCommand : IRequest<Result>
{
    public CreateGoalCommand(string title, decimal targetAmount, decimal monthlySavingAmount, int deadlineMonths)
    {
        Title = title;
        TargetAmount = targetAmount;
        MonthlySavingAmount = monthlySavingAmount;
        DeadlineMonths = deadlineMonths;
    }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public decimal MonthlySavingAmount { get; private set; }
    public int DeadlineMonths { get; private set; }
}