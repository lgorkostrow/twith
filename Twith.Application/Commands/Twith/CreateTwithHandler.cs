using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Factories;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.Twith
{
    public class CreateTwithHandler : IRequestHandler<CreateTwithCommand>
    {
        private readonly ITwithRepository _twithRepository;
        private readonly IUserRepository _userRepository;

        public CreateTwithHandler(ITwithRepository twithRepository, IUserRepository userRepository)
        {
            _twithRepository = twithRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = TwithFactory.Create(
                request.Id,
                request.Content, 
                await _userRepository.FindOrFailAsync(request.AuthorId)
            );

            await _twithRepository.SaveAsync(twith);

            return Unit.Value;
        }
    }
}