using IRM.Application.Inventory.Items.MotorcycleModel;
using IRM.Infrastructure.Supabase.Inventory.MotorcycleModel;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection.Inventory;

public static class DIMotorcycleModel
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddTransient<IMotorcycleModelReadRepository, MotorcycleModelReadRepository>();
        services.AddTransient<IMotorcycleModelWriteRepository, MotorcycleModelWriteRepository>();

        return services;
    }
}
