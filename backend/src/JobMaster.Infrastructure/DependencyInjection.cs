using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Infrastructure.Advertisements.Persistence;
using JobMaster.Infrastructure.Skills.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace JobMaster.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();

        return services;
    }
}