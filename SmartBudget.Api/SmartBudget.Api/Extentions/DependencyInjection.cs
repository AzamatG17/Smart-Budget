using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SmartBudget.Api.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApi(this IServiceCollection services, IConfiguration configuration)
    {
        AddDatabaseContext(services, configuration);

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
