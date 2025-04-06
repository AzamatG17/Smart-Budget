using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Features.Queries.StatisticsQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Features.Handlers.Statisticshandlers;

public class GetStatisticsHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetStatisticsQuery, List<StatisticsDto>>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<List<StatisticsDto>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = await FilterStatistics(request);

        return new List<StatisticsDto> { MapToStatistic(query, request) };
    }

    private async Task<List<Transaction>> FilterStatistics(GetStatisticsQuery q)
    {
        var query = _context.Transactions
            .Include(c => c.Category)
            .AsNoTracking()
            .AsQueryable();

        if (q.CategoryId != null)
        {
            query = query.Where(t => t.CategoryId == q.CategoryId);
        }
        if (q.TransactionType != null)
        {
            query = query.Where(t => t.Category.TransactionType == q.TransactionType);
        }
        if (q.Year != 0)
        {
            query = query.Where(t => t.DateAdded.Year == q.Year);
        }
        if (q.Month != 0)
        {
            query = query.Where(t => t.DateAdded.Month == q.Month);
        }

        return await query.ToListAsync();
    }

    private static StatisticsDto MapToStatistic(List<Transaction> transactions, GetStatisticsQuery q)
    {
        return new StatisticsDto(
            q.Year,
            q.Month,
            transactions.Sum(t => t.Amount),
            transactions.FirstOrDefault()?.Category?.TransactionType ?? null
        );
    }
}
