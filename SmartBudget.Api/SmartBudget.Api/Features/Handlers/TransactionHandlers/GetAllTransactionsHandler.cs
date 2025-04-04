using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Features.Queries.TransactionQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Handlers.TransactionHandlers;

public class GetAllTransactionsHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var transactions = await _context.Transactions
            .AsNoTracking()
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return transactions ?? [];
    }
}
