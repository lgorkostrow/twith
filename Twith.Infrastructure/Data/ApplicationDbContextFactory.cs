using Microsoft.EntityFrameworkCore;

namespace Twith.Infrastructure.Data
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }

        protected override string GetConnectionString()
        {
            return "DefaultConnection";
        }
    }
}