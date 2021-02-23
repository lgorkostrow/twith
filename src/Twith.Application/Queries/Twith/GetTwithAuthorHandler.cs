using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Common.Exceptions;
using Twith.Domain.Twith.Dtos;
using Twith.Domain.Twith.Queries;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.Twith
{
    public class GetTwithAuthorHandler : IRequestHandler<GetTwithAuthorQuery, AuthorDto>
    {
        private readonly ApplicationDbContext _context;

        public GetTwithAuthorHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AuthorDto> Handle(GetTwithAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Twiths.Where(t => t.Id == request.Id)
                .Select(t => new AuthorDto(t.Author))
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (author is null)
            {
                throw new EntityNotFoundException(nameof(Domain.Twith.Entities.Twith));
            }

            return author;
        }
    }
}