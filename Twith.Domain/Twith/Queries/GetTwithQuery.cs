using System;
using MediatR;
using Twith.Domain.Twith.Dtos;

namespace Twith.Domain.Twith.Queries
{
    public record GetTwithQuery : IRequest<TwithDetailedViewDto>
    {
        public Guid Id { get; }

        public GetTwithQuery(Guid id)
        {
            Id = id;
        }
    }
}