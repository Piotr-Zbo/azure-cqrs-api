namespace AzureCqrs.Api.Services;

public interface IQueueService
{
    public Task SendMessage<T>(T message, string queueName);
}