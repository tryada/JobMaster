namespace JobMaster.Api.Common.Cors;

public static class CorsServiceExtensions
{
    private const string AllowOriginPolicy = "Access-Control-Allow-Origin";

    public static IServiceCollection AddCorsServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowOriginPolicy, builder =>
            {
                builder.AllowAnyOrigin()
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