using System.Data;
using FluentValidation;

namespace FinanceGoals.Application.Commands.Transactions.Create;

/// <summary>
/// Represents the <see cref="CreateTransactionCommand"/> validator.
/// </summary>
public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(o => o.TransactionType).NotEmpty();
        RuleFor(o => o.Quantity).NotEmpty();
    }
}