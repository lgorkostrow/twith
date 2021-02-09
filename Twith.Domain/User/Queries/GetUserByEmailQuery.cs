using MediatR;
using Twith.Domain.User.Dtos;

namespace Twith.Domain.User.Queries
{
    public record GetUserByEmailQuery : IRequest<UserDetailedView>
    {
        public string Email { get; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}