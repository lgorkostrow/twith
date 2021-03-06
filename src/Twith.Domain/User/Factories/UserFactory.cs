﻿using System;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.User.ValueObjects;

namespace Twith.Domain.User.Factories
{
    public static class UserFactory
    {
        public static Entities.User Create(Guid id, string email, string firstName, string lastName, string nickName)
        {
            return new Entities.User(
                id,
                new Email(email),
                new Name(firstName),
                new Name(lastName),
                new NickName(nickName)
            );
        }
    }
}