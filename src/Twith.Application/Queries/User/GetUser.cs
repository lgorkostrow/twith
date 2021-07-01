using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Application.Dtos.User;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.User
{
    public record GetUserQuery : IRequest<UserDetailedViewDto>
    {
        public Guid Id { get; }

        public GetUserQuery(Guid id)
        {
            Id = id;
        }
    }
    
    public class GetUserInformationHandler : IRequestHandler<GetUserQuery, UserDetailedViewDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserInformationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<UserDetailedViewDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _context.Users.Where(u => u.Id.Equals(request.Id))
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