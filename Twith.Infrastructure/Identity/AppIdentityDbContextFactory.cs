using Microsoft.EntityFrameworkCore;

namespace Twith.Infrastructure.Identity
{
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactory<AppIdentityDbContext>
    {
        protected override AppIdentityDbContext CreateNewInstance(DbContextOptions<AppIdentityDbContext> options)
        {
            return new AppIdentityDbContext(options);
        }

        protected override string GetConnectionString()
        {
            return "IdentityConnection";
        }
    }
}