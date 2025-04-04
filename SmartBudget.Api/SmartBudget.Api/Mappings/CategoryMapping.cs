using AutoMapper;
using SmartBudget.Api.Features.Commands.CategoryCommands;
using SmartBudget.Api.Features.Commands.CategoryQueries;
using SmartBudget.Api.Models.DTOs;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Mappings;

public sealed class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType.ToString()));
        CreateMap<CategoryDto, Category>();

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
