using MediatR;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Commands.TransactionCommands;

public record CreateTransactionCommand(
    decimal Amount,
    string? Comment,
    int CategoryId
    ) : IRequest<TransactionDto>;
