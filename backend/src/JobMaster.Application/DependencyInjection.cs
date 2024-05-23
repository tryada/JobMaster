using System.Reflection;
using FluentValidation;
using JobMaster.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace JobMaster.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            configuration => {
                configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}