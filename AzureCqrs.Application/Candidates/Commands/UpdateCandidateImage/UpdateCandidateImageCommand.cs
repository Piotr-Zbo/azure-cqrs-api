using System.ComponentModel.DataAnnotations;
using AzureCqrs.Application.Common.Models;
using MediatR;

namespace AzureCqrs.Application.Candidates.Commands.UpdateCandidateImage;

public class UpdateCandidateImageCommand: IRequest<OperationResult<Guid>>
{
    /// <summary>
    /// Candidate Id
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// Base64 encoded image content
    /// </summary>
    public string ImageContent { get; set; }

}