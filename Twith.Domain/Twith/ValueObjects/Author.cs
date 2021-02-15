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

        private Author()
        {
        }

        public Author(Guid id, Name firstName, Name lastName, NickName nickName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }

        public Author(User.Entities.User user) : this(
            user.Id,
            new Name(user.FirstName.Value),
            new Name(user.LastName.Value),
            new NickName(user.NickName.Value)
        )
        {
        }
    }
}