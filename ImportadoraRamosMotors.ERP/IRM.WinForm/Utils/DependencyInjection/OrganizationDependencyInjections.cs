using IRM.WinForm.Organization.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.WinForm.Utils.DependencyInjection;

public static class OrganizationDependencyInjections
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Brand

        // Company

        // User
        services.AddTransient<FrmLoginView>();
        services.AddTransient<FrmUserView>();


        return services;
    }
}
