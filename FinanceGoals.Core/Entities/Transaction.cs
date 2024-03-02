using FinanceGoals.Core.Enumerations;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;

namespace FinanceGoals.Core.Entities;

/// <summary>
/// Represents a transaction.
/// </summary>
public class Transaction : Entity
{
    public Transaction(decimal quantity, ETransactionType eTransactionType, Guid idGoal)
    {
        Quantity = quantity;
        ETransactionType = eTransactionType;
        IdGoal = idGoal;
    }
    
    public Guid IdGoal { get; set; }
    public decimal Quantity { get; set; }
    public ETransactionType ETransactionType { get; set; }

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
    /// Checks if a transaction is a deposit type.
    /// </summary>
    /// <returns>A bool value</returns>
    public bool IsDeposit()
    {
        return ETransactionType == ETransactionType.Deposit;
    }
    
}