using System;
using Microsoft.IdentityModel.Tokens;

namespace Twith.Identity.Authorization
{
    public class JwtOptions
    {
        public int TTL { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public DateTime ExpiresAt => DateTime.UtcNow.AddSeconds(TTL);
    }
}