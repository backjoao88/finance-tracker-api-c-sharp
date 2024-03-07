using FinanceGoals.Core.Enumerations;

namespace FinanceGoals.Application.ViewModels;

/// <summary>
/// Represents a view model.
/// </summary>
public class GoalViewModel
{
    public GoalViewModel(Guid id, string title, decimal targetAmount, decimal totalAmount, DateTime start, DateTime end, EGoalStatus active, List<TransactionViewModel> transactions)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        TotalAmount = totalAmount;
        Start = start;
        End = end;
        Transactions = transactions;
        Active = active;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal TargetAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public EGoalStatus Active { get; set; }
    public List<TransactionViewModel> Transactions { get; set; }
}