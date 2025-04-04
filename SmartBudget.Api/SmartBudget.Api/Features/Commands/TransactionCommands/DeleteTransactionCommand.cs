using MediatR;

namespace SmartBudget.Api.Features.Commands.TransactionCommands;

public record DeleteTransactionCommand(
    int Id
    ) : IRequest<bool>;
