using MediatR;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Features.Queries.CategoryQueries;

public record GetAllCategoriesQuery() : IRequest<List<CategoryDto>>;
