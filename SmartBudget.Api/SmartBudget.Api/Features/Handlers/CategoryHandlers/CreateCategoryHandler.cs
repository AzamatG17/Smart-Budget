using AutoMapper;
using MediatR;
using SmartBudget.Api.Features.Commands.CategoryQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Features.Handlers.CategoryHandlers;

public class CreateCategoryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var category = _mapper.Map<Category>(request);

        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CategoryDto>(category);
    }
}
