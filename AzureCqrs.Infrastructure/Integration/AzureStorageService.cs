using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureCqrs.Application.Common.Models;
using AzureCqrs.Application.Common.Storage;

namespace AzureCqrs.Infrastructure.Integration;

public class AzureFileStorageService : IFileStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureFileStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<StorageFileInfo> GetFileAsync(string containerName, string fileName, CancellationToken cancellationToken = default)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        var blobDownloadResult = await blobClient.DownloadContentAsync(cancellationToken);

        return new StorageFileInfo(blobDownloadResult.Value.Content.ToStream(), blobDownloadResult.Value.Details);
    }

    public async Task UploadFileAsync(string containerName, Stream contentStream, string fileName, IDictionary<string,string> metadata, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        var options = new BlobUploadOptions();
        options.Tags = metadata;
        await blobClient.UploadAsync(contentStream, options, cancellationToken);
    }

    public async Task DeleteFileAsync(string containerName, string fileName, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, null, cancellationToken);
    }
}