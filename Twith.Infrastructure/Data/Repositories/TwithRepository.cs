using Twith.Domain.Twith.Repositories;

namespace Twith.Infrastructure.Data.Repositories
{
    public class TwithRepository : AbstractBaseRepository<Domain.Twith.Entities.Twith>, ITwithRepository
    {
        public TwithRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}  