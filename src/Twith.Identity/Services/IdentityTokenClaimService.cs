using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Twith.Identity.Authorization;
using Twith.Identity.Models;

namespace Twith.Identity.Services
{
    public class IdentityTokenClaimService : ITokenClaimsService
    {
        private readonly JwtOptions _jwtOptions;

        public IdentityTokenClaimService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public ClaimsIdentity GenerateClaimsIdentityForUser(ApplicationUser user)
        {
            return new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });
        }
        
        public string GetToken(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = _jwtOptions.ExpiresAt,
                SigningCredentials = _jwtOptions.SigningCredentials
            };

            return tokenHandler.WriteToken(
                tokenHandler.CreateToken(tokenDescriptor)
            );
        }
    }
}