using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Twith.Events;
using Twith.Infrastructure.Data;

namespace Twith.Application.Events.Twith
{
    public class RecountTwithLikes : INotificationHandler<TwithLikedEvent>
    {
        private readonly ApplicationDbContext _context;

        public RecountTwithLikes(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TwithLikedEvent notification, CancellationToken cancellationToken)
        {
            await _context.Database.ExecuteSqlRawAsync(@"
                UPDATE twiths t
                SET likes_count = s.likesCount 
                FROM (
                    SELECT COUNT(l.id) as likesCount
                    FROM likes l
                    WHERE l.twith_id = {0}
                ) s
                WHERE id = {0}", 
                notification.TwithId);
        }
    }
}