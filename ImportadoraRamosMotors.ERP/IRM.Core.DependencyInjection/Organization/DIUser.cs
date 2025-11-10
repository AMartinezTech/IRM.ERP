using IRM.Application.Organization.Users;
using IRM.Infrastructure.Supabase.Organization.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IRM.Core.DependencyInjection.Organization;

public static class DIUser
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<UserServices>();

        return services;
    }
}
