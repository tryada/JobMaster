using JobMaster.Infrastructure.Common.Utils;

namespace JobMaster.Api.Common.Cors;

public static class CorsServiceExtensions
{
    private const string AllowOriginPolicy = "Access-Control-Allow-Origin";

    public static IServiceCollection AddCorsServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowOriginPolicy, builder =>
            {
                builder.WithOrigins(configuration.GetAllowOrigin())
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static void UseCorsPolicy(this IApplicationBuilder app)
    {
        app.UseCors(AllowOriginPolicy);
    }
}