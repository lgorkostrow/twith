using System;
using MediatR;
using Twith.Domain.Twith.Dtos;

namespace Twith.Domain.Twith.Queries
{
    public record GetTwithQuery : IRequest<TwithDetailedViewDto>
    {
        public Guid Id { get; }
        
        public Guid CurrentUserId { get; }

        public GetTwithQuery(Guid id, Guid currentUserId)
        {
            Id = id;
            CurrentUserId = currentUserId;
        }
    }
}