using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AzureCqrs.Application;

public static class StartupRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(StartupRegistrations));

        return services;
    }
}