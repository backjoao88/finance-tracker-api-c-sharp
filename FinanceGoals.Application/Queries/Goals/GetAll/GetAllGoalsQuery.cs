using FinanceGoals.Application.ViewModels;
using MediatR;

namespace FinanceGoals.Application.Queries.Goals.GetAll;

/// <summary>
/// Represents a query to retrieve all goals.
/// </summary>
public class GetAllGoalsQuery : IRequest<List<GoalViewModel>>;