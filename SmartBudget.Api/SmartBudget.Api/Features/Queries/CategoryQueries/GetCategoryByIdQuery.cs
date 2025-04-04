using MediatR;
using SmartBudget.Api.Models.DTOs;

namespace SmartBudget.Api.Features.Queries.CategoryQueries;

public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto>;
