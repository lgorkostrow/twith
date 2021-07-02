using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Common.Exceptions;
using Twith.Infrastructure.Repositories;

namespace Twith.Infrastructure.PostgreSQL.Data.Repositories
{
    public class TwithRepository : AbstractBaseRepository<Domain.Twith.Entities.Twith>, ITwithRepository
    {
        public TwithRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Domain.Twith.Entities.Twith> FindOrFailWithUserLikesAsync(Guid id, Guid userId)
        {
            var twith = await Context.Twiths
                .Include(x => x.Likes.Where(l => l.Author.Id == userId))
                .SingleAsync(x => x.Id == id);
            if (twith is null)
            {
                throw new EntityNotFoundException(nameof(Domain.Twith.Entities.Twith));
            }
            
            return twith;
        }
    }
}  