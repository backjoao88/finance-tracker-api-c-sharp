using FinanceGoals.Core.Enumerations;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;

namespace FinanceGoals.Core.Entities;

/// <summary>
/// Represents the financial goal entity.
/// </summary>
public class Goal : Entity
{
    public Goal(string title, decimal targetAmount, decimal totalAmount, decimal monthlySavingAmount, DateTime start, DateTime end)
    {
        Title = title;
        TargetAmount = targetAmount;
        TotalAmount = totalAmount;
        MonthlySavingAmount = monthlySavingAmount;
        Active = EGoalStatus.Actived;
        Start = start;
        End = end;
    }
    public Goal(string title, decimal targetAmount, decimal monthlySavingAmount, int deadlineMonths = 1, decimal totalAmount = 0)
    {
        Title = title;
        TargetAmount = targetAmount;
        TotalAmount = totalAmount;
        MonthlySavingAmount = monthlySavingAmount;
        Active = EGoalStatus.Actived;
        Start = DateTime.Now;
        End = Start.AddMonths(deadlineMonths);
    }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal MonthlySavingAmount { get; private set; }
    public EGoalStatus Active { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public List<Transaction> Transactions { get; private set; } = null!;

    /// <summary>
    /// Deactivate the goal.
    /// </summary>
    public void Deactivate()
    {
        Active = EGoalStatus.Deactivated;
    }

    /// <summary>
    /// Checks if the total amount accumulated is equal or greater than the target amount.
    /// </summary>
    /// <returns>A bool value</returns>
    public bool TargetAmountReached()
    {
        return TotalAmount >= TargetAmount;
    }
    
    /// <summary>
    /// Represents a deposit operation.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public Result<Transaction> Deposit(decimal amount)
    {
        var newTransaction = new Transaction(amount, ETransactionType.Deposit, Id);
        var isValidResult = newTransaction.IsValid();
        if (isValidResult.IsFailure)
        {
            return Result.Fail<Transaction>(isValidResult.Error);
        }
        TotalAmount = TotalAmount + amount;
        return Result.Ok(newTransaction);
    }

    /// <summary>
    /// Represents a withdraw operation.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public Result<Transaction> Withdraw(decimal amount)
    {
        var newTransaction = new Transaction(amount, ETransactionType.Withdraw, Id);
        var isValidTransactionResult = newTransaction.IsValid();
        if (isValidTransactionResult.IsFailure)
        {
            return Result.Fail<Transaction>(isValidTransactionResult.Error);
        }
        var isFutureTotalAmountNegative = (TotalAmount-amount) <= 0;
        if (isFutureTotalAmountNegative)
        {
            return Result.Fail<Transaction>(DomainErrors.Goal.TotalNotNegative);
        }
        TotalAmount = TotalAmount - amount;
        return Result.Ok(newTransaction);
    }
    
}