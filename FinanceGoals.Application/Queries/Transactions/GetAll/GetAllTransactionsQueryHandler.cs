using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core;
using MediatR;

namespace FinanceGoals.Application.Queries.Transactions.GetAll;

/// <summary>
/// Represents the <see cref="GetAllTransactionsQuery"/> handler.
/// </summary>
public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllTransactionsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TransactionViewModel>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _unitOfWork.TransactionRepository.ReadAll();
        var transactionsViewModel = transactions
            .Select(o => new TransactionViewModel(o.Id, o.Quantity, o.TransactionType))
            .ToList();
        return transactionsViewModel;
    }
}