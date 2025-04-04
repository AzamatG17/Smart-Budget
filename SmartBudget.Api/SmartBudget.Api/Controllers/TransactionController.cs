using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.Api.Features.Commands.TransactionCommands;
using SmartBudget.Api.Features.Queries.TransactionQueries;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// Get all transactions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<TransactionDto>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllTransactionsQuery());
        return Ok(result);
    }

    /// <summary>
    /// Get transaction by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<TransactionDto>> GetByIdAsync(int id)
    {
        var result = await _mediator.Send(new GetTransactionByIdQuery(id));
        return Ok(result);
    }

    /// <summary>
    /// Create a new transaction
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TransactionDto>> CreateAsync([FromBody] CreateTransactionCommand command)
    {
        var result = await _mediator.Send(command);

        return result;
    }

    /// <summary>
    /// Update an existing transaction
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<TransactionDto>> UpdateAsync(int id, [FromBody] UpdateTransactionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Transaction ID mismatch.");
        }
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Delete a transaction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mediator.Send(new DeleteTransactionCommand(id));
        return NoContent();
    }
}
