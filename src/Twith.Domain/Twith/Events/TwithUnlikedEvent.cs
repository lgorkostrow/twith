using System;

namespace Twith.Domain.Twith.Events
{
    public record TwithUnlikedEvent : BaseTwithLikeEvent
    {
        public TwithUnlikedEvent(Guid twithId, Guid authorId, Guid likeId) : base(twithId, authorId, likeId)
        {
            
        }
    }
}