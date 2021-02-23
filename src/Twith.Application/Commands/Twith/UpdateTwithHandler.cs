﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Commands;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Application.Commands.Twith
{
    public class UpdateTwithHandler : IRequestHandler<UpdateTwithCommand>
    {
        private readonly ITwithRepository _twithRepository;

        public UpdateTwithHandler(ITwithRepository twithRepository)
        {
            _twithRepository = twithRepository;
        }

        public async Task<Unit> Handle(UpdateTwithCommand request, CancellationToken cancellationToken)
        {
            var twith = await _twithRepository.FindOrFailAsync(request.TwithId);
            
            twith.Update(new Content(request.Content));

            await _twithRepository.UpdateAsync(twith);
            
            return Unit.Value;
        }
    }
}