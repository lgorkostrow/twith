using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Twith.Dtos;
using Twith.Domain.Twith.Queries;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.Twith
{
    public class GetTwithHandler : IRequestHandler<GetTwithQuery, TwithDetailedViewDto>
    {
        private readonly ApplicationDbContext _context;

        public GetTwithHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<TwithDetailedViewDto> Handle(GetTwithQuery request, CancellationToken cancellationToken)
        {
            return (from t in _context.Twiths
                    where t.Id.Equals(request.Id)
                    select new TwithDetailedViewDto(
                        t.Id,
                        t.Content.Value,
                        t.CreatedAt,
                        new AuthorDto(t.Author))
                )
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}