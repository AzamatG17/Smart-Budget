using SmartBudget.Api.Models.Common;

namespace SmartBudget.Api.Models.Entities;

public class Transaction : AuditableEntity
{
    public required DateTime DateAdded { get; set; } = DateTime.Now;
    public required decimal Amount { get; set; }
    public string? Comment { get; set; }

    public required int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
