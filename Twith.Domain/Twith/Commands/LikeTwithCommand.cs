using System;
using MediatR;

namespace Twith.Domain.Twith.Commands
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
}