namespace FinanceGoals.Core.Primitives.Errors;

/// <summary>
/// Sets of domain errors.
/// </summary>
public static class DomainErrors
{
    public static Error NotFound = new Error("Entity.NotFound", "This record was not found.");

    public static class Transaction
    {
        public static Error NotNegative = new("Transaction.NotNegative", "A transaction must not be negative.");
    }

    public static class Goal
    {
        public static Error TotalNotNegative = new("Goal.TotalNotNegative", "The total amount must not be negative.");
    }
}