using System;
using System.Threading.Tasks;
using AzureCqrs.Api.Common;
using AzureCqrs.Application.Candidates.Commands.AddCandidate;
using AzureCqrs.Application.Common.Models;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Commands;

/// <summary>
///
/// </summary>
public class AddCandidate : ApiFunction
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public AddCandidate(IMediator mediator, ILogger<AddCandidate> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    // [OpenApiOperation(operationId: "addCandidate", tags: new[] { "name" }, Summary = "Adds a new candidate entry")]

    /// <summary>
    /// Adds a new candidate entry.
    /// </summary>
    /// <param name="req"></param>
    /// <param name="log"></param>
    /// <returns></returns>
    [FunctionName("AddCandidate")]
    [ProducesResponseType(typeof(OperationResult<Guid>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCandidateAsync(
        [RequestBodyType(typeof(AddCandidateCommand), "Add candidate command")]
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v2/candidates")]
        AddCandidateCommand req)
    {
        _logger.LogInformation("AddCandidate executing for {@AddCandidateCommand}", req);

        try
        {
            var addCandidateResult = await _mediator.Send(req);
            _logger.LogInformation("AddCandidate finished with result {@AddCandidateResult}", addCandidateResult);
            return GetActionResult(addCandidateResult);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "AddCandidate failed");
            throw;
        }
    }
}