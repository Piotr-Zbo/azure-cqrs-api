using AzureCqrs.Application.Common.Models;
using AzureCqrs.Application.Common.Queue;
using MediatR;

namespace AzureCqrs.Application.Candidates.Commands.AddCandidate;

public class AddCandidateHandler : IRequestHandler<AddCandidateCommand, OperationResult<Guid>>
{
    private readonly IQueueService _queueService;

    public AddCandidateHandler(IQueueService queueService)
    {
        _queueService = queueService;
    }

    public async Task<OperationResult<Guid>> Handle(AddCandidateCommand request, CancellationToken cancellationToken)
    {
        request.Id = Guid.NewGuid();
        await _queueService.SendMessage(request, "sbq-candidates");
        return OperationResult<Guid>.Success(request.Id);
    }
}