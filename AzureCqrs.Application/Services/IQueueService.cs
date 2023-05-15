namespace AzureCqrs.Application.Common.Interfaces;

public interface IQueueService
{
    public Task SendMessage<T>(T message, string queueName);
}