using AzureCqrs.Domain.Common;
using AzureCqrs.Domain.Entities;

namespace AzureCqrs.Domain.Candidates;

public interface ICandidateRepository : IRepository
{
    public Task Add(Candidate candidate);

    public ValueTask<Candidate?> GetById(Guid candidateId);
}