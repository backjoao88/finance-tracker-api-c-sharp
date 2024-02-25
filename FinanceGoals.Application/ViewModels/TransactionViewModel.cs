using FinanceGoals.Core.Enumerations;

namespace FinanceGoals.Application.ViewModels;

/// <summary>
/// Represents the transaction view model.
/// </summary>
public class TransactionViewModel
{
    public TransactionViewModel(Guid id, decimal quantity, TransactionTypeEnum transactionType)
    {
        Id = id;
        Quantity = quantity;
        TransactionType = transactionType;
    }
    public Guid Id { get; set; }
    public decimal Quantity { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
}