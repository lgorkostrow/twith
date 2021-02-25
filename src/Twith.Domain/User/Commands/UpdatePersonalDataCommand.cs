using System;
using MediatR;

namespace Twith.Domain.User.Commands
{
    public record UpdatePersonalDataCommand : IRequest
    {
        public Guid UserId { get; }

        public string FirstName { get; }
        
        public string LastName { get; }

        public UpdatePersonalDataCommand(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}