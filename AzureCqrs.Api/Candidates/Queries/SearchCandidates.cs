using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AzureCqrs.Api.Common;
using AzureCqrs.Application.Common.Models;
using AzureCqrs.Domain.Entities;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Queries;

public class SearchCandidates : ApiFunction
{
    public SearchCandidates()
    {
    }

    [FunctionName("SearchCandidates")]
    [ProducesResponseType(typeof(OperationResult<Candidate[]>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchCandidatesAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v2/candidates")]
        HttpRequest req,
        [Sql(
            @"
            SELECT TOP (100) [Id],[FirstName],[LastName],[Birthday],[City],[Skills],[Languages],[Certificates]
            FROM [dbo].[Candidate]
            ",
            "CandidatesDb",
            CommandType.Text)] IEnumerable<Candidate> items,
        ILogger log)
    {
        var result = items.ToArray();
        return GetActionResult(OperationResult<Candidate[]>.Success(result));
    }
}