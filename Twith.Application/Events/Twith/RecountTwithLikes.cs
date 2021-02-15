using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Twith.Events;

namespace Twith.Application.Events.Twith
{
    public class RecountTwithLikes : INotificationHandler<TwithLikedEvent>
    {
        public Task Handle(TwithLikedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(1231232);
            
            return Task.CompletedTask;
        }
    }
}