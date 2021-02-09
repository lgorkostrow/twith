using System;
using MediatR;
using Twith.Domain.User.Dtos;

namespace Twith.Domain.User.Queries
{
    public record GetUserQuery : IRequest<UserDetailedView>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
}