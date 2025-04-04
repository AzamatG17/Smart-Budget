using MediatR;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Queries.TransactionQueries;

public record GetAllTransactionsQuery : IRequest<List<TransactionDto>>;