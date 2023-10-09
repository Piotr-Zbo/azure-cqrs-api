using AzureCqrs.Application.Common.Models;
using AzureCqrs.Application.Common.Storage;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Application.Candidates.Commands.UpdateCandidateImage;

/// <summary>
///
/// </summary>
public class UpdateCandidateImageHandler : IRequestHandler<UpdateCandidateImageCommand, OperationResult<Guid>>
{
    private readonly IFileStorageService _fileStorageService;
    private readonly ILogger _logger;
    private readonly string _candidateImageContainerName;

    /// <summary>
    ///
    /// </summary>
    /// <param name="fileStorageService"></param>
    /// <param name="logger"></param>
    public UpdateCandidateImageHandler(IFileStorageService fileStorageService, ILogger<UpdateCandidateImageHandler> logger)
    {
        _fileStorageService = fileStorageService;
        _logger = logger;
        _candidateImageContainerName = "candidate-image";
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<OperationResult<Guid>> Handle(UpdateCandidateImageCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating candidate {CandidateId} image", request.Id);
        // _fileStorageService.UploadFileAsync(
        //     _candidateImageContainerName,
        //     new MemoryStream(Convert.FromBase64String(request.ImageContent)),
        //     request.Id,
        //     null



        return OperationResult<Guid>.Success(request.Id);
    }
}