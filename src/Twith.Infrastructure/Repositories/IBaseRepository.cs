﻿using System;
using System.Threading.Tasks;
using Twith.Domain.Common.Entities;

namespace Twith.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity?> FindAsync(Guid id);

        public Task<TEntity> FindOrFailAsync(Guid id);
        
        public Task<TEntity> SaveAsync(TEntity entity);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);

        public Task SaveEntitiesAsync();
    }
}