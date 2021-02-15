using System;
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
                new Author(user),
                new Content(content)
            );
        }
    }
}