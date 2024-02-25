namespace FinanceGoals.Application.ViewModels;

/// <summary>
/// Represents a view model.
/// </summary>
public class GoalViewModel
{
    public GoalViewModel(Guid id, string title, decimal targetAmount, decimal totalAmount, List<TransactionViewModel> transactions)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        TotalAmount = totalAmount;
        Transactions = transactions;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public List<TransactionViewModel> Transactions { get; set; }
}