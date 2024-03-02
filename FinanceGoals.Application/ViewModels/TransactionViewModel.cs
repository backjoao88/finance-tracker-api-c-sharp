using FinanceGoals.Core.Enumerations;

namespace FinanceGoals.Application.ViewModels;

/// <summary>
/// Represents the transaction view model.
/// </summary>
public class TransactionViewModel
{
    public TransactionViewModel(Guid id, decimal quantity, ETransactionType eTransactionType)
    {
        Id = id;
        Quantity = quantity;
        ETransactionType = eTransactionType;
    }
    public Guid Id { get; set; }
    public decimal Quantity { get; set; }
    public ETransactionType ETransactionType { get; set; }
}