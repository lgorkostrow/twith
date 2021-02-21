using MediatR;

namespace Twith.Domain.User.Queries
{
    public record IsUserWithEmailExistsQuery : IRequest<bool>
    {
        public string Email { get; }
        
        public IsUserWithEmailExistsQuery(string email)
        {
            Email = email;
        }
    }
}