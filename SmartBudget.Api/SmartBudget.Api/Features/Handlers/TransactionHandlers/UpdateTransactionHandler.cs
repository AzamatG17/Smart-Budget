using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Features.Commands.TransactionCommands;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Handlers.TransactionHandlers;

public class UpdateTransactionHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<UpdateTransactionCommand, TransactionDto>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    public async Task<TransactionDto> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var transaction = await _context.Transactions
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Transaction with id {request.Id} not found.");

        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
            ?? throw new KeyNotFoundException($"Category with id {request.CategoryId} not found.");

        _mapper.Map(request, transaction);

        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TransactionDto>(transaction);
    }
}
