using JobMaster.Infrastructure.Common.Utils;
using Microsoft.Extensions.Configuration;

namespace JobMaster.Infrastructure.Common.Utils;

public static partial class EnvironmentUtils
{
    private const string LocalConnectionStringName = "Local";
    private const string DockerConnectionStringName = "Docker";

    public static string GetConnectionString(this IConfiguration configuration)
    {
        var isRunningInContainer = configuration.IsRunningInDockerContainer();

        return isRunningInContainer
            ? configuration.GetConnectionString(DockerConnectionStringName)
            : configuration.GetConnectionString(LocalConnectionStringName);
    }
}