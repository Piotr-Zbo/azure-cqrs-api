using AzureCqrs.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Application.Candidates.Commands.UpdateCandidateImage;

/// <summary>
///
/// </summary>
public class UpdateCandidateImageHandler : IRequestHandler<UpdateCandidateImageCommand, OperationResult<Guid>>
{
    private readonly ILogger _logger;

    /// <summary>
    ///
    /// </summary>
    /// <param name="logger"></param>
    public UpdateCandidateImageHandler(ILogger<UpdateCandidateImageHandler> logger)
    {
        _logger = logger;
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
        return OperationResult<Guid>.Success(request.Id);
    }
}