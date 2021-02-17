using System;
using MediatR;

namespace Twith.Domain.Twith.Commands
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
}