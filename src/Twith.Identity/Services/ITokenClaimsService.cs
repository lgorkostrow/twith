using System.Security.Claims;
using Twith.Identity.Models;

namespace Twith.Identity.Services
{
    public interface ITokenClaimsService
    {
        public ClaimsIdentity GenerateClaimsIdentityForUser(ApplicationUser user);
        
        public string GetTokenAsync(ClaimsIdentity claimsIdentity);
    }
}