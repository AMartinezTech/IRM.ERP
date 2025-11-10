using IRM.Application.Inventory.Items.MotorcycleBrand;
using IRM.Application.Inventory.Items.MotorcycleColor;
using IRM.Application.Inventory.Items.MotorcycleModel;
using IRM.WinForm.Inventory;
using IRM.WinForm.Inventory.Item;
using IRM.WinForm.Inventory.MotorcycleBrand;
using IRM.WinForm.Inventory.MotorcycleModel;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.WinForm.Utils.DependencyInjection;

public static class InventoryDependencyInjections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Main view
        services.AddTransient<FrmInventoryMainView>();
        services.AddTransient<FrmInventoryLeftMenuView>();
        
        // Color
        services.AddTransient<MotorcycleColorServices>();
        services.AddTransient<FrmMotorcycleColorView>();

        // Brand
        services.AddTransient<MotorcycleBrandServices>();
        services.AddTransient<FrmMotorcycleBrandView>();

        // Model
        services.AddTransient<MotorcycleModelServices>();
        services.AddTransient<FrmMotorcycleModelView>();


        return services;
    }
}
