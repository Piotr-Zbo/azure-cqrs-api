using AzureCqrs.Api.Services;
using AzureCqrs.Application.Common.Models;
using MediatR;

namespace AzureCqrs.Application.Candidates.Commands.AddCandidate;

public class AddCandidateHandler : IRequestHandler<AddCandidateCommand, Result<Guid>>
{
    private readonly IQueueService _queueService;

    public AddCandidateHandler(IQueueService queueService)
    {
        _queueService = queueService;
    }

    public async Task<Result<Guid>> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
    {
        request.Id = Guid.NewGuid();
        await _queueService.SendMessage(request, "sbq-candidates");
        return Result<Guid>.Success(request.Id);
    }
}