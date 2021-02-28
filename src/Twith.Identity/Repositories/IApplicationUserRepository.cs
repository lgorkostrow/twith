using System.Threading.Tasks;

namespace Twith.Identity.Repositories
{
    public interface IApplicationUserRepository
    {
        public Task<bool> IsUserWithEmailExistsAsync(string email);
    }
}