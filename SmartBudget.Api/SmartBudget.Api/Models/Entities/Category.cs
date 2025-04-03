using SmartBudget.Api.Models.Common;
using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Models.Entities;

public class Category : AuditableEntity
{
    public required string Name { get; set; }
    public required TransactionType TransactionType { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; }
}
