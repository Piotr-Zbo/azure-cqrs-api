using Azure.Storage.Blobs.Models;

namespace AzureCqrs.Application.Common.Models;

/// <summary>
///
/// </summary>
public class StorageFileInfo
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="fileSteam"></param>
    public StorageFileInfo(Stream fileSteam, BlobDownloadDetails downloadDetails)
    {
        FileSteam = fileSteam;
        DownloadDetails = downloadDetails;
    }

    /// <summary>
    ///
    /// </summary>
    public Stream FileSteam { get; }

    public BlobDownloadDetails DownloadDetails { get; }
}