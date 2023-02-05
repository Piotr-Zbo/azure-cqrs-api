using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Queues;

public static class CandidateMessage
{
    [FunctionName("CandidateMessage")]
    public static async Task RunAsync(
        [ServiceBusTrigger("sbq-candidates", Connection = "Endpoint=sb://sb-azure-cqrs-dev.servicebus.windows.net/;SharedAccessKeyName=ReadAccess;SharedAccessKey=KS3BNgznJ47GoN8txaEbPNpiwRPxDgLFqIGW4/ew9zU=")] string myQueueItem,
        ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
    }
}