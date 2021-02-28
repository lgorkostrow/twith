using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Twith.Infrastructure.Data;
using Twith.Infrastructure.Identity;

namespace Twith.API
{
    public class Program
    {
        private const string EnableMigrations = "--enable-migrations";
        
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (args.Contains(EnableMigrations))
            {
                using (var scope = host.Services.CreateScope())
                {
                    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    applicationDbContext.Database.Migrate();
                
                    var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
                    identityDbContext.Database.Migrate();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
