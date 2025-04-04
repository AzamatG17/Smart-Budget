using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Exceptions;
using SmartBudget.Api.Features.Queries.TransactionQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Handlers.TransactionHandlers;

public class GetTransactionByIdHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTransactionByIdQuery, TransactionDto>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<TransactionDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var result = await _context.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException($"Transaction with id {request.Id} not found.");

        return _mapper.Map<TransactionDto>(result);
    }
}
