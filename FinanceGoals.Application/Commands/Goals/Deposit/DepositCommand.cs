using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Deposit;

/// <summary>
/// Represents the deposit command.
/// </summary>
public class DepositCommand : IRequest<Result>
{
    public DepositCommand(Guid idGoal, decimal amount)
    {
        IdGoal = idGoal;
        Amount = amount;
    }
    public Guid IdGoal { get; set; }
    public decimal Amount { get; set; }
}