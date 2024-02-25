namespace FinanceGoals.Core.Primitives;

/// <summary>
/// Represents a base entity.
/// </summary>
public class Entity
{
    public Guid Id { get; protected set; } = Guid.Empty;
}