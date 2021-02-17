using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Twith.Repositories;

namespace Twith.Infrastructure.Data.Repositories
{
    public class TwithRepository : AbstractBaseRepository<Domain.Twith.Entities.Twith>, ITwithRepository
    {
        public TwithRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Domain.Twith.Entities.Twith> FindAsyncWithUserLikeAsync(Guid id, Guid userId)
        {
            return await Context.Twiths
                .Include(x => x.Likes.Where(l => l.Author.Id == userId))
                .SingleAsync(x => x.Id == id);
        }
    }
}  