
using IRM.Application.Inventory.Items.MotorcycleBrand;
using IRM.Infrastructure.Supabase.Inventory.MotorcycleBrand;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection.Inventory;

public static class DIMotorcycleBrand
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IMotorcycleBrandWriteRepository, MotorcycleBrandWriteRepository>();
        services.AddScoped<IMotorcycleBrandReadRepository, MotorcycleBrandReadRepository>();
        return services;
    }
}
