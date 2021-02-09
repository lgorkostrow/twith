using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.User.Dtos;
using Twith.Domain.User.Queries;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, UserDetailedView>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByEmailHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserDetailedView> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return (from u in _context.Users
                    where u.Email.Value.Equals(request.Email)
                    select new UserDetailedView(
                        u.Id,
                        u.Email.Value,
                        u.FirstName.Value,
                        u.LastName.Value,
                        u.NickName.Value)
                )
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}