using AzureCqrs.Application.Common.Models;
using MediatR;

namespace AzureCqrs.Application.Candidates.Queries.GetCandidate;

public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, OperationResult<CandidateDto>>
{
    public GetCandidateByIdHandler()
    {
    }

    public async Task<OperationResult<CandidateDto>> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
    {
        request.Id = Guid.NewGuid();
        return OperationResult<CandidateDto>.Success(new CandidateDto()
        {
            Id = request.Id,
        });
    }
}