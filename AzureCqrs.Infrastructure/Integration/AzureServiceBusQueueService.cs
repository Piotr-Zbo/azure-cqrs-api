using System.Text;
using System.Text.Json;
using AzureCqrs.Api.Services;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Infrastructure.Integration;

public class AzureServiceBusQueueService : IQueueService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _log;

    public AzureServiceBusQueueService(IConfiguration configuration, ILogger log)
    {
        _configuration = configuration;
        _log = log;
    }

    public async Task SendMessage<T>(T message, string queueName)
    {
        var queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), queueName);
        var messageBody = JsonSerializer.Serialize(message);
        var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(messageBody));

        await queueClient.SendAsync(serviceBusMessage);
    }
}