using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;

namespace FinanceGoals.Core.Entities;

/// <summary>
/// Represents the financial goal entity.
/// </summary>
public class Goal : Entity
{
    public Goal(string title, decimal targetAmount, decimal monthlySavingAmount, DateTime start, DateTime end)
    {
        Title = title;
        TargetAmount = targetAmount;
        MonthlySavingAmount = monthlySavingAmount;
        Start = start;
        End = end;
    }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public decimal TotalAmount { get; private set; }
    public decimal MonthlySavingAmount { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public List<Transaction> Transactions { get; private set; } = null!;

    /// <summary>
    /// Checks if the total amount accumulated is equal or greater than the target amount.
    /// </summary>
    /// <returns>A bool value</returns>
    public bool TargetAmountReached()
    {
        return TotalAmount >= TargetAmount;
    }

    /// <summary>
    /// Updates the total goal amount.
    /// </summary>
    /// <param name="transaction"></param>
    public Result UpdateTotalAmount(Transaction transaction)
    {
        if (transaction.IsNegative())
        {
            return Result.Fail(DomainErrors.Transaction.NotNegative);
        }
        var newQuantity = transaction.IsDeposit()
            ? transaction.Quantity
            : transaction.Quantity * -1;
        var futureAmount = TotalAmount + newQuantity;
        if (futureAmount < 0)
        {
            return Result.Fail(DomainErrors.Goal.TotalNotNegative);
        }
        TotalAmount += newQuantity;
        return Result.Ok();
    }
    
    
    
}