using Microsoft.Extensions.DependencyInjection;
using Twith.Application.Service;
using Twith.Domain.Common.Services;
using Twith.Identity.Repositories;
using Twith.Identity.Services;
using Twith.Infrastructure.PostgreSQL.Data.Repositories;
using Twith.Infrastructure.Repositories;

namespace Twith.API.StartupExtensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITwithRepository, TwithRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
        }
    }
}