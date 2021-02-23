using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Twith.Infrastructure.Identity
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppIdentityDbContext _context;

        public ApplicationUserRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserWithEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email || u.UserName == email);
        }
    }
}