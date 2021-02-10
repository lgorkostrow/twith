using System;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Factories
{
    public static class TwithFactory
    {
        public static Entities.Twith Create(
            Guid id,
            string content,
            User.Entities.User user
        )
        {
            return new Entities.Twith(
                id,
                new Author(
                    user.Id, 
                    new Name(user.FirstName.Value), 
                    new Name(user.LastName.Value),
                    new NickName(user.NickName.Value)
                ),
                new Content(content)
            );
        }
    }
}