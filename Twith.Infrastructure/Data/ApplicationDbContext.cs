using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Common.Entities;
using Twith.Domain.User.Entities;
using Twith.Infrastructure.Data.EntityConfigurations;

namespace Twith.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IDomainEventDispatcher dispatcher
        ) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Twith.Entities.Twith> Twiths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TwithConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
        }

        public async Task<int> SaveEntitiesAsync()
        {
            // foreach (var entry in ChangeTracker.Entries())
            // {
            //     foreach (var pi in entry.Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
            //     {
            //         entry.Property(pi.Name).CurrentValue = pi.GetValue(entry.Entity);
            //     }
            // }

            var res = await SaveChangesAsync(); 

            var domainEventEntities = ChangeTracker.Entries<BaseEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                await _dispatcher.Dispatch(entity.DomainEvents);
            }

            return res;
        }
    }
}