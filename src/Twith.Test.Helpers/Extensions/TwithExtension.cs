using System;
using Bogus;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Test.Helpers.Extensions
{
    public static class TwithExtension
    {
        public static Domain.Twith.Entities.Twith CreateTwith(this ITest test, Faker faker)
        {
            return new(
                Guid.NewGuid(),
                CreateAuthor(test, faker),
                new Content(faker.Lorem.Sentences(1))
            );
        }

        public static Author CreateAuthor(this ITest test, Faker faker)
        {
            return new(
                Guid.NewGuid(),
                new Name(faker.Name.FirstName()),
                new Name(faker.Name.LastName()),
                new NickName(faker.Random.AlphaNumeric(50))
            );
        }
        
        public static Author CreateAuthor(this ITest test, Guid id, string firstName, string lastName, string nickName)
        {
            return new(
                id,
                new Name(firstName),
                new Name(lastName),
                new NickName(nickName)
            );
        }
    }
}