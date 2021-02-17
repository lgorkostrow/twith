using System;

namespace Twith.Domain.Twith.Events
{
    public record TwithLikedEvent : BaseTwithLikeEvent
    {
        public TwithLikedEvent(Guid twithId, Guid authorId, Guid likeId) : base(twithId, authorId, likeId)
        {
            
        }
    }
}