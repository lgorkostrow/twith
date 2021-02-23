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
    public class GetUserInformationHandler : IRequestHandler<GetUserQuery, UserDetailedViewDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserInformationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserDetailedViewDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return (from u in _context.Users
                    where u.Id.Equals(request.Id)
                    select new UserDetailedViewDto(
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