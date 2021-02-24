using System;
using System.Collections.Generic;
using Twith.Domain.Common.Queries;
using Twith.Domain.Twith.Dtos;

namespace Twith.Domain.Twith.Queries
{
    public record GetTwithLikesQuery : BaseListQuery<List<LikeDto>>
    {
        public Guid TwithId { get; }

        public GetTwithLikesQuery(int limit, int offset, Guid twithId) : base(limit, offset)
        {
            TwithId = twithId;
        }
    }
}