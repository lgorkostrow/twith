using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Repositories;

namespace Twith.Application.Commands.Twith
{
    public class DeleteTwithCommand : IRequest
    {
        public Guid TwithId { get; }

        public DeleteTwithCommand(Guid twithId)
        {
            TwithId = twithId;
        }
    }
    
    public class DeleteTwithHandler : IRequestHandler<DeleteTwithCommand>
    {
        private readonly ITwithRepository _repository;

        public DeleteTwithHandler(ITwithRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = await _repository.FindAsync(request.TwithId);
            if (twith is not null)
            {
                await _repository.DeleteAsync(twith);
            }
            
            return Unit.Value;
        }
    }
}