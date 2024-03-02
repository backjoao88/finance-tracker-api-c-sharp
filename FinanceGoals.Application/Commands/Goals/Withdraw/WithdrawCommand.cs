using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Goals.Withdraw;

/// <summary>
/// Represents a withdraw command.
/// </summary>
public class WithdrawCommand : IRequest<Result>
{
    public WithdrawCommand(Guid idGoal, decimal amount)
    {
        IdGoal = idGoal;
        Amount = amount;
    }
    public Guid IdGoal { get; set; }
    public decimal Amount { get; set; }
}