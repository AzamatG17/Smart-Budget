using MediatR;

namespace SmartBudget.Api.Features.Commands.CategoryCommands;

public record DeleteCategoryCommand(
    int Id
    ) : IRequest<bool>;
