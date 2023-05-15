using System;
using System.IO;
using System.Threading.Tasks;
using AzureCqrs.Api.Common;
using AzureCqrs.Application.Candidates.Commands.UpdateCandidateImage;
using AzureCqrs.Application.Common.Models;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureCqrs.Api.Candidates.Commands;

/// <summary>
///
/// </summary>
public class UploadCandidateImage : ApiFunction
{
    private readonly IMediator _mediator;
    private readonly ILogger<UploadCandidateImage> _logger;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="logger"></param>
    public UploadCandidateImage(IMediator mediator, ILogger<UploadCandidateImage> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [FunctionName("UploadCandidateImage")]
    [ProducesResponseType(typeof(OperationResult<Guid>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadCandidateImageAsync(
        [RequestBodyType(typeof(UpdateCandidateImageCommand), "Upload candidate image command")]
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v2/candidate/{id}/image")]
        UpdateCandidateImageCommand req,
        [Blob("candidate-image/{id}", Connection = "CandidatesStorage")]
        TextWriter storageWriter)
    {
        _logger.LogInformation("UploadCandidateImage executing for {@UpdateCandidateImageCommand}", req);
        var updateCandidateImageResult = await _mediator.Send(req);
        _logger.LogInformation("UploadCandidateImage finished with result {@UpdateCandidateImageResult}", updateCandidateImageResult);
        return GetActionResult(updateCandidateImageResult);
    }
}