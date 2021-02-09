using System;
using Twith.Domain.Common.ValueObjects;

namespace Twith.Domain.Twith.ValueObjects
{
    public record Author
    {
        public Guid Id { get; }

        public Name FirstName { get; }
        
        public Name LastName { get; }
        
        public NickName NickName { get; }

        public Author(Guid id, Name firstName, Name lastName, NickName nickName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}