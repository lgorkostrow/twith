using System;
using MediatR;

namespace Twith.Domain.Twith.Commands
{
    public record UpdateTwithCommand : IRequest
    {
        public Guid TwithId { get; }

        public string Content { get; }

        public UpdateTwithCommand(Guid twithId, string content)
        {
            TwithId = twithId;
            Content = content;
        }
    }
}