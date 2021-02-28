using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Twith.Identity;
using Twith.Infrastructure.Data;

namespace Twith.API.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static void AddCustomizedDatabase(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment env
        )
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                        .UseSnakeCaseNamingConvention();

                    if (!env.IsProduction())
                    {
                        options.EnableDetailedErrors();
                        options.EnableSensitiveDataLogging();
                    }
                });

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options
                    .UseNpgsql(configuration.GetConnectionString("IdentityConnection"))
                    .UseSnakeCaseNamingConvention();
                
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });
        }
    }
}