﻿using System;
using System.Threading.Tasks;
using Twith.Domain.Common.Repositories;

namespace Twith.Domain.Twith.Repositories
{
    public interface ITwithRepository : IBaseRepository<Entities.Twith>
    {
        public Task<Entities.Twith> FindOrFailWithUserLikesAsync(Guid id, Guid userId);
    }
}