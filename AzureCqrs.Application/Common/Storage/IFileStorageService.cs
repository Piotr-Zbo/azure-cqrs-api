using AzureCqrs.Application.Common.Models;

namespace AzureCqrs.Application.Common.Storage;

/// <summary>
///
/// </summary>
public interface IFileStorageService
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<StorageFileInfo> GetFileAsync(string containerName, string fileName, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="contentStream"></param>
    /// <param name="fileName"></param>
    /// <param name="metadata"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task UploadFileAsync(string containerName, Stream contentStream, string fileName, IDictionary<string,string> metadata, CancellationToken cancellationToken);

    /// <summary>
    ///
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="fileName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task DeleteFileAsync(string containerName, string fileName, CancellationToken cancellationToken);
}