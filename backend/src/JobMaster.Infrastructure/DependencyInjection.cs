using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.Authentication.Interfaces;
using JobMaster.Application.Common.Persistence;
using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Infrastructure.Advertisements.Persistence;
using JobMaster.Infrastructure.Authentication;
using JobMaster.Infrastructure.Common;
using JobMaster.Infrastructure.Common.Persistence;
using JobMaster.Infrastructure.Common.Persistence.Interceptors;
using JobMaster.Infrastructure.Skills.Persistence;
using JobMaster.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobMaster.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddPersistence()
            .AddAuthentication();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<IPasswordProvider, PasswordProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddDbContext<JobMasterDbContext>(
            options => options.UseSqlServer("Server=E14;Database=JobMaster;Integrated Security=SSPI;TrustServerCertificate=true")
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<PublishDomainEventsInterceptor>();

        return services;
    }
}