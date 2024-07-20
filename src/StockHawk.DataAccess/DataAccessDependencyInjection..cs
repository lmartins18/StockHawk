using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockHawk.DataAccess.Repositories;

namespace StockHawk.DataAccess;

public static class DataAccessDependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ActivityLogRepository>();
        services.AddScoped<CategoryRepository>();
        services.AddScoped<CustomerRepository>();
        services.AddScoped<OrderItemRepository>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<OrganizationRepository>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<RoleRepository>();
        services.AddScoped<SupplierRepository>();
    }
}
