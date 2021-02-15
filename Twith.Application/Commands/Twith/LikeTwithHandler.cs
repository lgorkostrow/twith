﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.Twith.ValueObjects;
using Twith.Domain.User.Repositories;

namespace Twith.Application.Commands.Twith
{
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
            var twith = await _twithRepository.FindOrFailAsync(request.TwithId);

            twith.Like(new Author(
                await _userRepository.FindOrFailAsync(request.UserId)
            ));

            await _twithRepository.SaveEntitiesAsync();
            
            return Unit.Value;
        }
    }
}