using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Exceptions;
using SmartBudget.Api.Features.Commands.CategoryCommands;
using SmartBudget.Api.Interfaces;

namespace SmartBudget.Api.Features.Handlers.CategoryHandlers;

public class DeleteCategoryHandler(IApplicationDbContext context) : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException($"Category with id {request.Id} not found.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
