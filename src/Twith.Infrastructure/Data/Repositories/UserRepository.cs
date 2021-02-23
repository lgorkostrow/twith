using Twith.Domain.User.Entities;
using Twith.Domain.User.Repositories;

namespace Twith.Infrastructure.Data.Repositories
{
    public class UserRepository : AbstractBaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}  