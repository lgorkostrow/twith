using System;
using MediatR;

namespace Twith.Domain.User.Commands
{
    public record CreateUserCommand : IRequest
    {
        public Guid Id { get; }
        
        public string Email { get; }
        
        public string FirstName { get; }
        
        public string LastName { get; }
        
        public string NickName { get; }

        public CreateUserCommand(Guid id, string email, string firstName, string lastName, string nickName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}