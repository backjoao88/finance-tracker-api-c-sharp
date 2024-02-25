using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core;
using FinanceGoals.Core.Primitives;
using FinanceGoals.Core.Primitives.Errors;
using MediatR;

namespace FinanceGoals.Application.Queries.Transactions.GetById;

/// <summary>
/// Represents the <see cref="GetTransactionByIdQuery"/> handler.
/// </summary>
public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Result<TransactionViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransactionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TransactionViewModel>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _unitOfWork
            .TransactionRepository
            .ReadById(request.Id);
        if (transaction is null)
        {
            return Result.Fail<TransactionViewModel>(DomainErrors.NotFound);
        }
        return Result.Ok(new TransactionViewModel(transaction.Id, transaction.Quantity, transaction.TransactionType));
    }
}