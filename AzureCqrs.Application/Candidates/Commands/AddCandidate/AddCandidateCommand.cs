using System.ComponentModel.DataAnnotations;
using AzureCqrs.Application.Common.Models;
using MediatR;

namespace AzureCqrs.Application.Candidates.Commands.AddCandidate;

/// <summary>
/// Command for creating new candidate.
/// </summary>
public class AddCandidateCommand : IRequest<Result<Guid>>
{
    /// <summary>
    /// Candidate Id
    /// </summary>
    [Required]
    public Guid Id { get; set; }

    /// <summary>
    /// First name of a candidate.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of a candidate.
    /// </summary>
    [Required]
    public string LastName { get; set; }
}