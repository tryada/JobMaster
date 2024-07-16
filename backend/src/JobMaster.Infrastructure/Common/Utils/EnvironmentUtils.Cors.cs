using Microsoft.Extensions.Configuration;

namespace JobMaster.Infrastructure.Common.Utils;

public static partial class EnvironmentUtils
{
    private const string LocalAllowOriginName = "AllowOriginLocal";
    private const string DockerAllowOriginName = "AllowOriginDocker";

    public static string GetAllowOrigin(this IConfiguration configuration)
    {
        var isRunningInContainer = configuration.IsRunningInDockerContainer();

        return isRunningInContainer
            ? configuration.GetAllowOrigin(DockerAllowOriginName)
            : configuration.GetAllowOrigin(LocalAllowOriginName);
    }

    private static string GetAllowOrigin(this IConfiguration configuration, string allowOriginName)
    {
        return configuration.GetValue<string>($"Cors:{allowOriginName}") ?? string.Empty;
    }
}