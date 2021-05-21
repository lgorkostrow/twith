using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public record IsUserWithNickNameExistsQuery : IRequest<bool>
    {
        public string NickName { get; }
        
        public IsUserWithNickNameExistsQuery(string nickName)
        {
            NickName = nickName;
        }
    }
    
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