using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBudget.Api.Features.Queries.StatisticsQueries;

namespace SmartBudget.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    [HttpGet]
    public async Task<IActionResult> GetStatistics([FromQuery] GetStatisticsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
