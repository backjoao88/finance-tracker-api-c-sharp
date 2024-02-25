using FinanceGoals.Core.Enumerations;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;

namespace FinanceGoals.Core.Entities;

/// <summary>
/// Represents a transaction.
/// </summary>
public class Transaction : Entity
{
    public Transaction(decimal quantity, TransactionTypeEnum transactionType, Guid idGoal)
    {
        Quantity = quantity;
        TransactionType = transactionType;
        IdGoal = idGoal;
    }
    public Guid IdGoal { get; set; }
    public decimal Quantity { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }

    /// <summary>
    /// Checks if a transaction is valid.
    /// </summary>
    /// <returns></returns>
    public Result IsValid()
    {
        if (Quantity <= 0)
        {
            return Result.Fail(DomainErrors.Transaction.NotNegative);
        }
        return Result.Ok();
    }

    /// <summary>
    /// Check if the transaction quantity is negative.
    /// </summary>
    /// <returns>A bool value</returns>
    public bool IsNegative()
    {
        return Quantity < 0;
    }

    /// <summary>
    /// Checks if a transaction is a deposit type.
    /// </summary>
    /// <returns>A bool value</returns>
    public bool IsDeposit()
    {
        return TransactionType == TransactionTypeEnum.Deposit;
    }
    
}