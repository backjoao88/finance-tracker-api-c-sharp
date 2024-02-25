using FinanceGoals.Api.Abstractions;
using FinanceGoals.Application.Commands.Goals.Create;
using FinanceGoals.Application.Queries.Goals.GetAll;
using FinanceGoals.Application.Queries.Goals.GetById;
using FinanceGoals.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceGoals.Api.Controllers;

/// <summary>
/// Wrapper all goal endpoints.
/// </summary>
[ApiController]
[Route("/api/goals")]
public class GoalController : ApiController
{
    private readonly IMediator _mediator;

    public GoalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to save a new goal.
    /// </summary>
    /// <param name="createGoalCommand"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreateGoalCommand createGoalCommand)
    { 
        var result = await _mediator.Send(createGoalCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint to retrieve a goal by id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromBody] GetGoalByIdQuery getGoalByIdQuery)
    {
        var result = await _mediator.Send(getGoalByIdQuery);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    /// <summary>
    /// Endpoint to retrieve all goals.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var getAllGoalsCommand = new GetAllGoalsQuery();
        var goals = await _mediator.Send(getAllGoalsCommand);
        return Ok(goals);
    }

}