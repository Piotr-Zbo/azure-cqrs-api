using System.ComponentModel.DataAnnotations;

namespace AzureCqrs.Application.Candidates.Commands.UpdateCandidate;

/// <summary>
/// Command for updating existing candidate.
/// </summary>
public class UpdateCandidateCommand
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