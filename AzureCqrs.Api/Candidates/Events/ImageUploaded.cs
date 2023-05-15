using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Events;

/// <summary>
///
/// </summary>
public class ImageUploaded
{
    private readonly ILogger _logger;

    /// <summary>
    ///
    /// </summary>
    /// <param name="logger"></param>
    public ImageUploaded(ILogger<ImageUploaded> logger)
    {
        _logger = logger;
    }

    [FunctionName("ImageUploaded")]
    public async Task ImageUploadedAsync(
        [BlobTrigger("samples-workitems/{name}", Connection = "")]
        Stream myBlob,
        string name)
    {
        _logger.LogInformation("Image Blob trigger function Processed blob\n Name:{Name} \n Size: {BlobLength} Bytes", name, myBlob.Length);
    }
}