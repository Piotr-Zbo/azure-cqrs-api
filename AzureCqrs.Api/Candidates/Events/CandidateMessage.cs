using System;
using System.Threading.Tasks;
using AzureCqrs.Application.Candidates.Commands.AddCandidate;
using AzureCqrs.Domain.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureCqrs.Api.Candidates.Events;

public static class CandidateMessage
{
    [FunctionName("CandidateMessage")]
    public static async Task CandidateEventAsync(
        [ServiceBusTrigger("sbq-candidates", Connection = "CandidatesApiServiceBus")]
        string myQueueItem,
        int deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        [Sql("dbo.Candidate", "CandidatesDb")] IAsyncCollector<Candidate> items,
        ILogger log)
    {
        log.LogInformation("Candidate ServiceBus queue trigger function processed message: {@QueueItem}", myQueueItem);

        var candidateEvent = JsonConvert.DeserializeObject<AddCandidateCommand>(myQueueItem);

        var candidate = new Candidate()
        {
            Id = candidateEvent.Id,
            FirstName = candidateEvent.FirstName,
            LastName = candidateEvent.LastName,
        };

        await items.AddAsync(candidate);
        await items.FlushAsync();
    }
}