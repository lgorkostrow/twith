using System;
using MediatR;

namespace Twith.Domain.Twith.Commands
{
    public class DeleteTwithCommand : IRequest
    {
        public Guid TwithId { get; }

        public DeleteTwithCommand(Guid twithId)
        {
            TwithId = twithId;
        }
    }
}