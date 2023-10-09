using AzureCqrs.Application.Common.Models;
using MediatR;

namespace AzureCqrs.Application.Candidates.Queries.GetCandidate;

public class GetCandidateByIdQuery : IRequest<OperationResult<CandidateDto>>
{
    public GetCandidateByIdQuery()
    {

    }

    /// <summary>
    /// Candidate Id
    /// </summary>
    public Guid Id { get; set; }
}