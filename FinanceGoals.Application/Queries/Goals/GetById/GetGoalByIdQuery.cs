using FinanceGoals.Application.ViewModels;
using FinanceGoals.Core.Primitives;
using MediatR;

namespace FinanceGoals.Application.Queries.Goals.GetById;

/// <summary>
/// Represents a query to get a goal by ID.
/// </summary>
public class GetGoalByIdQuery : IRequest<Result<GoalViewModel>>
{
    public GetGoalByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}