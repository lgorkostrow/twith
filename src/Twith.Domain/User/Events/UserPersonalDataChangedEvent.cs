using System;
using Twith.Domain.Common.Events;
using Twith.Domain.Common.ValueObjects;

namespace Twith.Domain.User.Events
{
    public record UserPersonalDataChangedEvent : IDomainEvent
    {
        public Guid UserId { get; }
        
        public Name FirstName { get; }
        
        public Name LastName { get; }

        public UserPersonalDataChangedEvent(Guid userId, Name firstName, Name lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}