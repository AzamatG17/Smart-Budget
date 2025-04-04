using MediatR;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Enums;

namespace SmartBudget.Api.Features.Commands.CategoryCommands;

public record UpdateCategoryCommand(
    int Id,
    string Name,
    TransactionType TransactionType
    ) : IRequest<CategoryDto>;
