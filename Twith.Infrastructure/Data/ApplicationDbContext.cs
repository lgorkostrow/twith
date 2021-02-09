using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Entities;
using Twith.Infrastructure.Data.EntityConfigurations;

namespace Twith.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                foreach (var pi in entry.Entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    entry.Property(pi.Name).CurrentValue = pi.GetValue(entry.Entity);
                }
            }
            return base.SaveChanges();
        }
    }
}