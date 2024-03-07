using FinanceGoals.Api.Abstractions;
using FinanceGoals.Application.Commands.Goals.Create;
using FinanceGoals.Application.Commands.Goals.Deactivate;
using FinanceGoals.Application.Commands.Goals.Delete;
using FinanceGoals.Application.Commands.Goals.Deposit;
using FinanceGoals.Application.Commands.Goals.Withdraw;
using FinanceGoals.Application.Queries.Goals.GetAll;
using FinanceGoals.Application.Queries.Goals.GetById;
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
    /// Endpoint to deposit an amount into a goal.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="depositCommand"></param>
    /// <returns></returns>
    [HttpPatch("deposit/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Deposit(Guid id, [FromBody] DepositCommand depositCommand)
    {
        depositCommand.IdGoal = id;
        var result = await _mediator.Send(depositCommand);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint to withdraw an amount into a goal.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="withdrawCommand"></param>
    /// <returns></returns>
    [HttpPatch("withdraw/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Withdraw(Guid id, [FromBody] WithdrawCommand withdrawCommand)
    {
        withdrawCommand.IdGoal = id;
        var result = await _mediator.Send(withdrawCommand);
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
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
    
    /// <summary>
    /// Endpoint to deactivate a goal.
    /// </summary>
    [HttpPatch("deactivate/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Deactivate(Guid id, DeactivateGoalCommand deactivateGoalCommand)
    {
        deactivateGoalCommand.IdGoal = id;
        var result = await _mediator.Send(deactivateGoalCommand);
        return result.IsSuccess ? NoContent() : NotFound();
    }

    /// <summary>
    /// Endpoint to delete a goal.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteGoalCommand deleteGoalCommand)
    {
        deleteGoalCommand.IdGoal = id;
        var result = await _mediator.Send(deleteGoalCommand);
        return result.IsSuccess ? NoContent() : NotFound();
    }

}