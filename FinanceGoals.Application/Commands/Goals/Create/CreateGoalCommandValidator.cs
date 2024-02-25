using FluentValidation;

namespace FinanceGoals.Application.Commands.Goals.Create;

/// <summary>
/// Represents a <see cref="CreateGoalCommand"/> validator.
/// </summary>
public class CreateGoalCommandValidator : AbstractValidator<CreateGoalCommand>
{
    public CreateGoalCommandValidator()
    {
        RuleFor(o => o.Title).NotEmpty();
        RuleFor(o => o.TargetAmount).NotEmpty();
    }
}