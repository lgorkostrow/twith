using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Dtos;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public record GetUserByEmailQuery : IRequest<UserDetailedViewDto>
    {
        public string Email { get; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
    
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserDetailedViewDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByEmailHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserDetailedViewDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return _context.Users.Where(u => u.Email.Value.Equals(request.Email))
                .Select(u => new UserDetailedViewDto(
                    u.Id,
                    u.Email.Value,
                    u.FirstName.Value,
                    u.LastName.Value,
                    u.NickName.Value)
                )
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}