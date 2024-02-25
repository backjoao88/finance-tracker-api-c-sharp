using FinanceGoals.Core.Enumerations;
using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Commands.Transactions.Create;

/// <summary>
/// Represents a create transaction command.
/// </summary>
public class CreateTransactionCommand : IRequest<Result>
{
    public CreateTransactionCommand(Guid idGoal, decimal quantity, TransactionTypeEnum transactionType)
    {
        IdGoal = idGoal;
        Quantity = quantity;
        TransactionType = transactionType;
    }
    public Guid IdGoal { get; set; }
    public decimal Quantity { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
}