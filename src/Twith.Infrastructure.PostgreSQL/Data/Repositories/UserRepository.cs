using Twith.Domain.User.Entities;
using Twith.Infrastructure.Repositories;

namespace Twith.Infrastructure.PostgreSQL.Data.Repositories
{
    public class UserRepository : AbstractBaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}  