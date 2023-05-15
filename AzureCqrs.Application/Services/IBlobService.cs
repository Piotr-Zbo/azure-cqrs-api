using Azure.Storage.Blobs.Models;

namespace AzureCqrs.Application.Services;

public interface IFileStorageService
{
    public Task<BlobInfo> GetFileAsync(string containerName, string fileName, CancellationToken cancellationToken);

    public Task UploadFileAsync(string containerName, string content, string fileName, CancellationToken cancellationToken);

    public Task DeleteFileAsync(string containerName, string fileName, CancellationToken cancellationToken);
}