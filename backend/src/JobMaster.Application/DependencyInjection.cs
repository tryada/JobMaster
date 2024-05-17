using Microsoft.Extensions.DependencyInjection;

namespace JobMaster.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            configuration => configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            );

        return services;
    }
}