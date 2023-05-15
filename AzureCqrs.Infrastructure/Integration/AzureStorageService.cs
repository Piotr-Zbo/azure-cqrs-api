using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureCqrs.Application.Services;

namespace AzureCqrs.Infrastructure.Integration;

public class AzureFileStorageService : IFileStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureFileStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<BlobInfo> GetFileAsync(string containerName, string fileName, CancellationToken cancellationToken = default)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        var blobDownloadResult = await blobClient.DownloadContentAsync(cancellationToken);

        return new BlobInfo( blobDownloadResult.Value.Content., blobDownloadResult.Value.Details);
    }

    public Task UploadFileAsync(string containerName, string content, string fileName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFileAsync(string containerName, string fileName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}