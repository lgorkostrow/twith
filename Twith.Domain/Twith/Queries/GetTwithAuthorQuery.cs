using System;
using MediatR;
using Twith.Domain.Twith.Dtos;

namespace Twith.Domain.Twith.Queries
{
    public record GetTwithAuthorQuery : IRequest<AuthorDto>
    {
        public Guid Id { get; }

        public GetTwithAuthorQuery(Guid id)
        {
            Id = id;
        }
    }
}