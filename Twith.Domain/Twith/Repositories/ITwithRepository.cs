using System;
using System.Threading.Tasks;
using Twith.Domain.Common.Repositories;

namespace Twith.Domain.Twith.Repositories
{
    public interface ITwithRepository : IBaseRepository<Entities.Twith>
    {
        public Task<Entities.Twith> FindAsyncWithUserLikeAsync(Guid id, Guid userId);
    }
}