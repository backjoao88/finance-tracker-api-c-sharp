namespace FinanceGoals.Core.Primitives.Errors;

/// <summary>
/// Represents a domain error.
/// </summary>
public record Error
{
    /// <summary>
    /// Empty error.
    /// </summary>
    public static Error Empty = new Error(string.Empty, string.Empty);
    
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; set; }
    public string Message { get; set; }
}