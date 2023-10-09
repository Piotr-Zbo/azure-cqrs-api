namespace AzureCqrs.Application.Common.Queue;

public interface IQueueService
{
    public Task SendMessage<T>(T message, string queueName);
}