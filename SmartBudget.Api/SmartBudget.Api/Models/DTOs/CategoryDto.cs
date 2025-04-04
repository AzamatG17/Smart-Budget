using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Models.DTOs;

public record CategoryDto(
    int Id,
    string Name,
    string TransactionType
    );
