using System;
using System.Threading.Tasks;
using AzureCqrs.Application.Candidates.Commands.AddCandidate;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Commands;

public static class AddCandidate
{
    // [OpenApiOperation(operationId: "addCandidate", tags: new[] { "name" }, Summary = "Adds a new candidate entry")]
    [FunctionName("AddCandidate")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public static async Task<IActionResult> RunAsync(
        [RequestBodyType(typeof(AddCandidateCommand), "name")]
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] AddCandidateCommand req,
        ISender mediator,
        ILogger log)
    {
        log.LogInformation("AddCandidate executing");

        //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //var command = JsonConvert.DeserializeObject<AddCandidateCommand>(requestBody);

        var candidateId = await mediator.Send(req);

        return new OkObjectResult(candidateId);
    }
}