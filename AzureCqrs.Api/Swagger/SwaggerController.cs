using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace AzureCqrs.Api.Swagger;

public static class SwaggerController
{
    [SwaggerIgnore]
    [FunctionName("Swagger")]
    public static Task<HttpResponseMessage> GetSwaggerDoc(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/json")] HttpRequestMessage req,
        [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
    {
        return Task.FromResult(swashBuckleClient.CreateSwaggerJsonDocumentResponse(req));
    }

    [SwaggerIgnore]
    [FunctionName("SwaggerUI")]
    public static Task<HttpResponseMessage> GetSwaggerUI(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/ui")] HttpRequestMessage req,
        [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
    {
        return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
    }
}