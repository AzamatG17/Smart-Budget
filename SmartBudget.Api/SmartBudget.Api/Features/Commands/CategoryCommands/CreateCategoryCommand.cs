using MediatR;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Features.Commands.CategoryQueries;

public record CreateCategoryCommand(
    string Name,
    TransactionType TransactionType
    ) : IRequest<CategoryDto>;
