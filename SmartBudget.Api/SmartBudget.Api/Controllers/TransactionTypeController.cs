using Microsoft.AspNetCore.Mvc;
using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionTypeController : ControllerBase
{

    /// <summary>
    /// Get all transaction types.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<TransactionType>> GetAllAsync()
    {
        var transactionTypeNames = Enum.GetNames(typeof(TransactionType)).ToList();

        return Ok(transactionTypeNames);
    }
}
