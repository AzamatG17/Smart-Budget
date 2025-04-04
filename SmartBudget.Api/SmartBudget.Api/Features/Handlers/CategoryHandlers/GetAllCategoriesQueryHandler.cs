using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Features.Queries.CategoryQueries;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Handlers.CategoryHandlers;

public sealed class GetAllCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var categories = await _context.Categories
            .AsNoTracking()
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return categories ?? [];
    }
}
