using JobMaster.Api.Authentication.Setup;
using JobMaster.Api.Common.Cors;
using JobMaster.Api.Common.Exceptions;
using JobMaster.Api.Common.Mapping;

namespace JobMaster.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddCorsServices(configuration);

        services.AddMapping();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddProblemDetails();
        services.AddExceptionHandler<JobMasterExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddJwt();

        return services;
    }
}