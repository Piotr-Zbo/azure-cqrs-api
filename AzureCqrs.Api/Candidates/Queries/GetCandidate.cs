using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AzureCqrs.Api.Common;
using AzureCqrs.Application.Common.Models;
using AzureCqrs.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Queries;

public class GetCandidate : ApiFunction
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public GetCandidate(IMediator mediator, ILogger<GetCandidate> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="req"></param>
    /// <param name="log"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [FunctionName("GetCandidate")]
    [ProducesResponseType(typeof(OperationResult<Candidate[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCandidateAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v2/candidate/{id}")]
        HttpRequest req,
        Guid id,
        [Sql(
            @"
            IF (@id IS NULL or @id = '')
                SELECT TOP (100) [Id],[FirstName],[LastName],[Birthday],[City],[Skills],[Languages],[Certificates]
                FROM [dbo].[Candidate]
            ELSE
                SELECT [Id],[FirstName],[LastName],[Birthday],[City],[Skills],[Languages],[Certificates]
                FROM [dbo].[Candidate]
                WHERE Id = @id
            ",
            "CandidatesDb",
            CommandType.Text,
            "@id={id}")] IEnumerable<Candidate> items,
        ILogger log)
    {
        var result = items.ToArray();
        return GetActionResult(OperationResult<Candidate[]>.Success(result));
    }
}