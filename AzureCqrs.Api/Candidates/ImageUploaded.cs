using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates;

public static class ImageUploaded
{
    [FunctionName("ImageUploaded")]
    public static async Task RunAsync([BlobTrigger("samples-workitems/{name}", Connection = "")] Stream myBlob,
        string name, ILogger log)
    {
        log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

    }
}