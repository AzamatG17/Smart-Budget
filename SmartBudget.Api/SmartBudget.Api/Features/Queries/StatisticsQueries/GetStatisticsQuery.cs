using MediatR;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Features.Queries.StatisticsQueries;

public record GetStatisticsQuery(
    int? CategoryId,
    TransactionType? TransactionType,
    int Year,
    int Month
    ) : IRequest<List<StatisticsDto>>;
