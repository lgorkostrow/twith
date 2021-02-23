using MediatR;
using Twith.Domain.User.Dtos;

namespace Twith.Domain.User.Queries
{
    public record GetUserByEmailQuery : IRequest<UserDetailedViewDto>
    {
        public string Email { get; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}