using IRM.Core.DependencyInjection.Inventory;
using IRM.Core.DependencyInjection.Organization;
using IRM.Infrastructure.Supabase.Http;
using IRM.Infrastructure.Supabase.Shared.CacheServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection;

public static class CoreDependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration config)
    {
        var url = config["Supabase:Url"] ?? throw new ArgumentNullException(paramName: "url");
        var apiKey = config["Supabase:ApiKey"] ?? throw new ArgumentNullException(paramName: "apiKey");

        // Supabase factory
        services.AddSingleton<ISupabaseClientFactory>(_ =>  new SupabaseClientFactory(url, apiKey));
        
        // Memory cache
        services.AddSingleton<ICacheService, CacheService>();

        DIMotorcycleCatalog.AddService(services);
        DIMotorcycleColor.AddService(services);
        DIMotorcycleBrand.AddService(services);
        DIMotorcycleModel.AddService(services);
        DIUser.AddService(services);

        return services;
    }
}
