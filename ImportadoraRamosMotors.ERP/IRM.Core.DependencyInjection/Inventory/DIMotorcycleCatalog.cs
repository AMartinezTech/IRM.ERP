using IRM.Application.Inventory.Items.Motorcycle.Catalog;
using IRM.Infrastructure.Supabase.Inventory.Motorcycle.Catalog;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection.Inventory;

public static class DIMotorcycleCatalog
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddTransient<IMotorcycleCatalogReadRepository, MotorcycleCatalogReadRepository>();
        services.AddTransient<IMotorcycleCatalogWriteRepository, MotorcycleCatalogWriteRepository>();
        return services;
    }
}
