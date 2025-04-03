namespace SmartBudget.Api.Models.Common;

public class AuditableEntity : EntityBase
{
    public DateTime CreatedAtUtc { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastUpdatedAtUtc { get; set; }
    public string? LastUpdatedBy { get; set; }
}
