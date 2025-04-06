using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Models.DTOs;

public record StatisticsDto(
    int? Year,
    int? Month,
    decimal? TotalAmount,
    TransactionType? TransactionType
    );
