using Microsoft.Extensions.Configuration;

namespace JobMaster.Infrastructure.Common.Utils;

public static partial class EnvironmentUtils
{
    private const string RunningInDockerContainerEnv = "ASPNETCORE_RUN_IN_DOCKER_CONTAINER";
    private const string RunningInDockerContainerEnvValue = "true";

    public static bool IsRunningInDockerContainer(this IConfiguration configuration)
    {
        return configuration[RunningInDockerContainerEnv] == RunningInDockerContainerEnvValue;
    }
}