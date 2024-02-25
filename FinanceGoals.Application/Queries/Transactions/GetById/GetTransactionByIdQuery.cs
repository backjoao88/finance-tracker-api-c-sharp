using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Queries.Transactions.GetById;

/// <summary>
/// Represents a get transaction query by id.
/// </summary>
public class GetTransactionByIdQuery : IRequest<Result<TransactionViewModel>>
{
    public GetTransactionByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}