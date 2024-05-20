using JobMaster.Api.Common.Cors;
using JobMaster.Api.Common.Mapping;

namespace JobMaster.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddCorsServices();

        services.AddMapping();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}