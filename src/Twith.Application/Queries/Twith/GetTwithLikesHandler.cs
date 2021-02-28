using System.Collections.Generic;
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
    public class GetTwithLikesHandler : IRequestHandler<GetTwithLikesQuery, List<LikeDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetTwithLikesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<LikeDto>> Handle(GetTwithLikesQuery request, CancellationToken cancellationToken)
        {
            return _context.Likes
                .Take(request.Limit)
                .Skip(request.Offset)
                .OrderByDescending(l => l.Author.Id == request.CurrentUserId)
                .ThenByDescending(l => l.CreatedAt)
                .Where(l => l.Twith.Id == request.TwithId)
                .Select(l => new LikeDto(l))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}