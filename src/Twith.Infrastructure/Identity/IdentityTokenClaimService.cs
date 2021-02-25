using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Twith.Infrastructure.Identity
{
    public class IdentityTokenClaimService : ITokenClaimsService
    {
        private readonly byte[] _jwtSecretKey;
        private readonly int _ttl;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityTokenClaimService(byte[] jwtSecretKey, int ttl, UserManager<ApplicationUser> userManager)
        {
            _jwtSecretKey = jwtSecretKey;
            _ttl = ttl;
            _userManager = userManager;
        }

        public async Task<string> GetTokenAsync(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim> {new Claim(ClaimTypes.Name, userName), new Claim(ClaimTypes.NameIdentifier, user.Id)};

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddSeconds(_ttl),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtSecretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}