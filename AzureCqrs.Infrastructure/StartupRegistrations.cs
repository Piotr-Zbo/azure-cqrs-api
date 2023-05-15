using Azure.Storage.Blobs;
using AzureCqrs.Application.Common.Interfaces;
using AzureCqrs.Infrastructure.Integration;
using Microsoft.Extensions.DependencyInjection;

namespace AzureCqrs.Infrastructure;

public static class StartupRegistrations
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CandidatesStorage");
        services.AddTransient<IQueueService, AzureServiceBusQueueService>();
        services.AddSingleton(x => new BlobServiceClient(connectionString));

        return services;
    }
}