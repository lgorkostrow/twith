using System;
using Twith.Domain.Common.Events;

namespace Twith.Domain.Twith.Events
{
    public abstract record BaseTwithLikeEvent : IDomainEvent
    {
        public Guid TwithId { get; }
        
        public Guid AuthorId { get; }
        
        public Guid LikeId { get; }

        public BaseTwithLikeEvent(Guid twithId, Guid authorId, Guid likeId)
        {
            TwithId = twithId;
            AuthorId = authorId;
            LikeId = likeId;
        }
    }
}