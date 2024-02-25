using FinanceGoals.Api.Abstractions;
using FinanceGoals.Application.Commands.Transactions.Create;
using FinanceGoals.Application.Queries.Goals.GetAll;
using FinanceGoals.Application.Queries.Transactions.GetAll;
using FinanceGoals.Application.Queries.Transactions.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceGoals.Api.Controllers;

/// <summary>
/// Represents the transaction endpoints.
/// </summary>
[ApiController]
[Route("/api/transactions")]
public class TransactionController : ApiController
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint to save a new transaction.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreateTransactionCommand createTransactionCommand)
    {
        var result = await _mediator.Send(createTransactionCommand);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    /// <summary>
    /// Endpoint to retrieve a transaction by id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromBody] GetTransactionByIdQuery getTransactionByIdQuery)
    {
        var result = await _mediator.Send(getTransactionByIdQuery);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);    
    }
    
    /// <summary>
    /// Endpoint to retrieve all transactions.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var getAllTransactionsQuery = new GetAllTransactionsQuery();
        var goals = await _mediator.Send(getAllTransactionsQuery);
        return Ok(goals);
    }
}