using AzureCqrs.Api.Services;
using AzureCqrs.Infrastructure.Integration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureCqrs.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IQueueService, AzureServiceBusQueueService>();

        return services;
    }
}