using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Exceptions;
using SmartBudget.Api.Features.Queries.CategoryQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Handlers.CategoryHandlers;

public class GetCategoryByIdHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var result = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException($"Category with id {request.Id} not found.");

        return _mapper.Map<CategoryDto>(result);
    }
}
