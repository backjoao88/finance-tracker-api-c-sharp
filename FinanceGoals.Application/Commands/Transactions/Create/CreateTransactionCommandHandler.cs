using System.Xml.XPath;
using FinanceGoals.Core;
using FinanceGoals.Core.Entities;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using MediatR;

namespace FinanceGoals.Application.Commands.Transactions.Create;

/// <summary>
/// Represents the <see cref="CreateTransactionCommand"/> handler.
/// </summary>
public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var goal = await _unitOfWork.GoalRepository.ReadById(request.IdGoal);
        if (goal is null)
        {
            return Result.Fail<Goal>(DomainErrors.NotFound);
        }
        var transaction = new Transaction(request.Quantity, request.TransactionType, goal.Id);
        var result = goal.UpdateTotalAmount(transaction);
        if (result.IsFailure)
        {
            return result;
        }
        await _unitOfWork.TransactionRepository.Save(transaction);
        await _unitOfWork.Complete();
        return Result.Ok();
    }
}