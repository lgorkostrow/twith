using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Repositories;

namespace Twith.Application.Commands.Twith
{
    public class UnlikeTwithHandler : IRequestHandler<UnlikeTwithCommand>
    {
        private readonly ITwithRepository _twithRepository;

        public UnlikeTwithHandler(ITwithRepository twithRepository)
        {
            _twithRepository = twithRepository;
        }

        public async Task<Unit> Handle(UnlikeTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = await _twithRepository.FindAsyncWithUserLikeAsync(request.TwithId, request.UserId);

            twith.Unlike(request.UserId);

            await _twithRepository.SaveEntitiesAsync();
            
            return Unit.Value;
        }
    }
}