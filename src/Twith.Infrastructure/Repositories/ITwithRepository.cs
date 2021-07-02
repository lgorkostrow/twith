using System;
using System.Threading.Tasks;

namespace Twith.Infrastructure.Repositories
{
    public interface ITwithRepository : IBaseRepository<Domain.Twith.Entities.Twith>
    {
        public Task<Domain.Twith.Entities.Twith> FindOrFailWithUserLikesAsync(Guid id, Guid userId);
    }
}