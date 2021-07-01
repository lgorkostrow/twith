using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Twith.Domain.Common.ValueObjects;
using Twith.Domain.User.Entities;
using Twith.Domain.User.ValueObjects;
using Twith.Identity;
using Twith.Identity.Entities;
using Twith.Infrastructure.Data;

namespace Twith.API.Test.Helpers
{
    public static class Utils
    {
        private static readonly Faker _faker = new Faker();

        public static async Task Initialize(
            ApplicationDbContext applicationDbContext,
            AppIdentityDbContext identityDbContext
        )
        {
            var applicationUsers = GenerateApplicationUsers();
            var users = GenerateUsers(applicationUsers);

            await identityDbContext.AddRangeAsync(applicationUsers);
            await applicationDbContext.AddRangeAsync(users);
        }

        private static IEnumerable<User> GenerateUsers(IEnumerable<ApplicationUser> applicationUsers)
        {
            foreach (var applicationUser in applicationUsers)
            {
                yield return new User(
                    Guid.Parse(applicationUser.Id),
                    new Email(applicationUser.Email),
                    new Name(_faker.Person.FirstName),
                    new Name(_faker.Person.LastName),
                    new NickName(_faker.Random.String2(10, 15))
                );
            }
        }

        private static IEnumerable<ApplicationUser> GenerateApplicationUsers(int count = 10)
        {
            for (int i = 0; i < count; i++)
            {
                var email = _faker.Person.Email;

                yield return new ApplicationUser() {UserName = email, Email = email, EmailConfirmed = true};
            }
        }
    }
}