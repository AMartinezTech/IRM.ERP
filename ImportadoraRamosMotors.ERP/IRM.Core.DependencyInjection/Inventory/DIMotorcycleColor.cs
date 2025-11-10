using IRM.Application.Inventory.Items.MotorcycleColor;
using IRM.Infrastructure.Supabase.Inventory.MotorcycleColor;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection.Inventory;

public static class DIMotorcycleColor
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IMotorcycleColorWriteRepository, MotorcycleColorWriteRepository>();
        services.AddScoped<IMotorcycleColorReadRepository, MotorcycleColorReadRepository>();

        return services;
    }
}
