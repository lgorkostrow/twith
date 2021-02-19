using System;
using Twith.Domain.Common.Entities;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.User.ValueObjects;

namespace Twith.Domain.User.Entities
{
    public class User : BaseEntity
    {
        public Guid Id { get; }

        public Email Email { get; }

        public Name FirstName { get; }

        public Name LastName { get; }

        public NickName NickName { get; }

        protected User()
        {
        }

        public User(Guid id, Email email, Name firstName, Name lastName, NickName nickName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
        }
    }
}