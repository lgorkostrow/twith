using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public class IsUserWithNickNameExistsHandler : IRequestHandler<IsUserWithNickNameExistsQuery, bool>
    {
        private readonly ApplicationDbContext _context;

        public IsUserWithNickNameExistsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(IsUserWithNickNameExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.NickName.Value == request.NickName, cancellationToken);
        }
    }
}