using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using SmartBudget.Api.Validations.CommandValidations;
using FluentValidation.AspNetCore;
using SmartBudget.Api.Mappings;

namespace SmartBudget.Api.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApi(this IServiceCollection services, IConfiguration configuration)
    {
        AddDatabaseContext(services, configuration);

        services.AddAutoMapper(typeof(CategoryMapping).Assembly);
        services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidation>();
        services.AddFluentValidationAutoValidation();

        return services;
    }

    private static void AddDatabaseContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
