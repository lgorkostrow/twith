using Microsoft.Extensions.DependencyInjection;
using Twith.Application.Service;
using Twith.Domain.Common.Services;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.User.Repositories;
using Twith.Identity.Repositories;
using Twith.Identity.Services;
using Twith.Infrastructure.Data.Repositories;

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