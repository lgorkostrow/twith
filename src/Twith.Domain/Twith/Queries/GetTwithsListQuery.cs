using System;
using System.Collections.Generic;
using Twith.Domain.Common.Queries;
using Twith.Domain.Twith.Dtos;

namespace Twith.Domain.Twith.Queries
{
    public record GetTwithsListQuery : BaseListQuery<List<TwithListViewDto>>
    {
        public Guid CurrentUserId { get; }

        public GetTwithsListQuery(int limit, int offset, Guid currentUserId) : base(limit, offset)
        {
            CurrentUserId = currentUserId;
        }
    }
}