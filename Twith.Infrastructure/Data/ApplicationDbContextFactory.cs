using Microsoft.EntityFrameworkCore;

namespace Twith.Infrastructure.Data
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContextFactory()
        {
        }

        public ApplicationDbContextFactory(IDomainEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options, _dispatcher);
        }

        protected override string GetConnectionString()
        {
            return "DefaultConnection";
        }
    }
}