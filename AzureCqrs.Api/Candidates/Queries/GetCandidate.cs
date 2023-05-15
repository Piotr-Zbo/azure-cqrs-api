using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureCqrs.Api.Candidates.Queries;

public static class GetCandidate
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="req"></param>
    /// <param name="log"></param>
    /// <returns></returns>
    [FunctionName("GetCandidate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IActionResult> GetCandidateAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v2/candidate/{id}")] HttpRequest req, ILogger log)
    {
        string name = req.Query["name"];

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        name = name ?? data?.name;

        return name != null
            ? (ActionResult)new OkObjectResult($"Hello, {name}")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

    }
}