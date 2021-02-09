using System;
using System.Threading.Tasks;
using Twith.Domain.Common.Entities;
using Twith.Domain.Common.Exceptions;
using Twith.Domain.Common.Repositories;

namespace Twith.Infrastructure.Data.Repositories
{
    public abstract class AbstractBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext Context;

        protected AbstractBaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await Context.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> FindOrFailAsync(Guid id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            if (entity is null)
            {
                throw new EntityNotFoundException(typeof(TEntity).Name);
            }
            
            return entity;
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
        
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}