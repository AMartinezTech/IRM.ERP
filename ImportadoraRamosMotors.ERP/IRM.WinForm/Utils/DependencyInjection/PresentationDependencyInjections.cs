using IRM.WinForm.Utils.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.WinForm.Utils.DependencyInjection;

public static class PresentationDependencyInjections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        InventoryDependencyInjections.AddServices(services);

        OrganizationDependencyInjections.AddServices(services);

        // Main
        services.AddTransient<FrmMainView>();
        services.AddTransient<IFormFactory, FormFactory>();

        return services;
    }
}
