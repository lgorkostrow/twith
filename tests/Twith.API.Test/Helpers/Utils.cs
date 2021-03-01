using System.Collections.Generic;
using Twith.Domain.User.Entities;
using Twith.Identity;
using Twith.Infrastructure.Data;

namespace Twith.API.Test.Helpers
{
    public static class Utils
    {
        public static void InitializeApplicationDbForTests(ApplicationDbContext context)
        {
            
        }
        
        public static void InitializeIdentityDbForTests(AppIdentityDbContext context)
        {
            
        }

        private static IList<User> GetUsers()
        {
            return new List<User>()
            {
                
            };
        }
    }
}