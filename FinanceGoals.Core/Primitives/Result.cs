using FinanceGoals.Core.Primitives.Errors;

namespace FinanceGoals.Core.Primitives;

/// <summary>
/// Represents a friendly domain result.
/// </summary>
public class Result
{
    public Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; set; }

    public static Result Ok() => new(true, Error.Empty);
    public static Result<TValue> Ok<TValue>(TValue value) => new(true, Error.Empty, value);
    public static Result Fail(Error error) => new(false, error);
    public static Result<TValue> Fail<TValue>(Error error) => new(false, error, default!);
    
}

/// <summary>
/// Represents a friendly generic domain result.
/// </summary>
public class Result<TValue> : Result
{
    public TValue Value { get; set; }

    public Result(bool isSuccess, Error error, TValue value) : base(isSuccess, error)
    {
        Value = value;
    }
}