namespace SmartBudget.Api.Models.DTOs;

public record TransactionDto(
    int Id,
    DateTime DateAdded,
    decimal Amount,
    string? Comment,
    int CategoryId,
    string CategoryName,
    string CategoryTransactionType
    );
