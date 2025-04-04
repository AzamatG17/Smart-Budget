using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.Api.Features.Commands.CategoryCommands;
using SmartBudget.Api.Features.Commands.CategoryQueries;
using SmartBudget.Api.Features.Queries.CategoryQueries;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Get all categories
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    /// <summary>
    /// Get category by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<CategoryDto>> GetBtIdAsync(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(result);
    }

    /// <summary>
    /// Create a new category
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody] CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);

        return result;
    }

    /// <summary>
    /// Update an existing category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult<CategoryDto>> UpdateAsync(int id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Category ID mismatch.");
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _mediator.Send( new DeleteCategoryCommand(id));
        return NoContent();
    }   
}
