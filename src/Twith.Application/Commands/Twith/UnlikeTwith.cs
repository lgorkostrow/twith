using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Infrastructure.Repositories;

namespace Twith.Application.Commands.Twith
{
    public record UnlikeTwithCommand : IRequest
    {
        public Guid TwithId { get; }
        
        public Guid UserId { get; }

        public UnlikeTwithCommand(Guid twithId, Guid userId)
        {
            TwithId = twithId;
            UserId = userId;
        }
    }
    
    public class UnlikeTwithHandler : IRequestHandler<UnlikeTwithCommand>
    {
        private readonly ITwithRepository _twithRepository;

        public UnlikeTwithHandler(ITwithRepository twithRepository)
        {
            _twithRepository = twithRepository;
        }

        public async Task<Unit> Handle(UnlikeTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = await _twithRepository.FindOrFailWithUserLikesAsync(request.TwithId, request.UserId);

            twith.Unlike(request.UserId);

            await _twithRepository.SaveEntitiesAsync();
            
            return Unit.Value;
        }
    }
}