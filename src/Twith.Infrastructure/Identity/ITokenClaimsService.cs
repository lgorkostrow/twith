using System.Threading.Tasks;

namespace Twith.Infrastructure.Identity
{
    public interface ITokenClaimsService
    {
        public Task<string> GetTokenAsync(string userName);
    }
}