using MediatR;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Commands.TransactionCommands;

public record UpdateTransactionCommand(
    int Id,
    decimal Amount,
    string? Comment,
    DateTime Date,
    int CategoryId
    ) : IRequest<TransactionDto>;
