using FinanceGoals.Application.ViewModels;
using MediatR;

namespace FinanceGoals.Application.Queries.Transactions.GetAll;

public class GetAllTransactionsQuery : IRequest<List<TransactionViewModel>>;