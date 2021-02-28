using Microsoft.Extensions.DependencyInjection;
using Twith.Application.Service;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.User.Repositories;
using Twith.Identity.Repositories;
using Twith.Identity.Services;
using Twith.Infrastructure.Data;
using Twith.Infrastructure.Data.Repositories;
using Twith.Infrastructure.Identity;

namespace Twith.IoC
{
    public static class IoCConfiguration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infrastructure 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITwithRepository, TwithRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
        }
    }
}