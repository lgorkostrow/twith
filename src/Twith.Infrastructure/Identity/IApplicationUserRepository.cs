using System.Threading.Tasks;

namespace Twith.Infrastructure.Identity
{
    public interface IApplicationUserRepository
    {
        public Task<bool> IsUserWithEmailExistsAsync(string email);
    }
}