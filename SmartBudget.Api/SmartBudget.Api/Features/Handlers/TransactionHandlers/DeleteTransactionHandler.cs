using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Features.Commands.TransactionCommands;
using SmartBudget.Api.Interfaces;

namespace SmartBudget.Api.Features.Handlers.TransactionHandlers;

public class DeleteTransactionHandler(IApplicationDbContext context) : IRequestHandler<DeleteTransactionCommand, bool>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var transaction = await _context.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Transaction with id {request.Id} not found.");

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
