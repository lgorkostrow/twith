using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.Twith.ValueObjects;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.Twith
{
    public record LikeTwithCommand : IRequest
    {
        public Guid TwithId { get; }
        
        public Guid UserId { get; }

        public LikeTwithCommand(Guid twithId, Guid userId)
        {
            TwithId = twithId;
            UserId = userId;
        }
    }
    
    public class LikeTwithHandler : IRequestHandler<LikeTwithCommand>
    {
        private readonly ITwithRepository _twithRepository;
        private readonly IUserRepository _userRepository;

        public LikeTwithHandler(ITwithRepository twithRepository, IUserRepository userRepository)
        {
            _twithRepository = twithRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(LikeTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = await _twithRepository.FindOrFailWithUserLikesAsync(request.TwithId, request.UserId);

            twith.Like(new Author(
                await _userRepository.FindOrFailAsync(request.UserId)
            ));

            await _twithRepository.SaveEntitiesAsync();
            
            return Unit.Value;
        }
    }
}