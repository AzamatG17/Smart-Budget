using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Exceptions;
using SmartBudget.Api.Features.Commands.TransactionCommands;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Features.Handlers.TransactionHandlers;

public class CreateTransactionHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<TransactionDto> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken)
            ?? throw new EntityNotFoundException($"Category with id {command.CategoryId} not found.");

         var transaction = _mapper.Map<Transaction>(command);

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TransactionDto>(transaction);
    }
}
