using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public class IsUserWithEmailExistsHandler : IRequestHandler<IsUserWithEmailExistsQuery, bool>
    {
        private readonly ApplicationDbContext _context;

        public IsUserWithEmailExistsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(IsUserWithEmailExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Email.Value == request.Email, cancellationToken);
        }
    }
}