using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace JobMaster.Api.Authentication.Setup;

public static class JwtServiceExtensions
{
    public static void AddJwt(this IServiceCollection services)
    {
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
    }
}