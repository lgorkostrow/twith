using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Application.Dtos.Twith;
using Twith.Domain.Common.Queries;
using Twith.Infrastructure.PostgreSQL.Data;

namespace Twith.Application.Queries.Twith
{
    public record GetTwithLikesQuery : BaseListQuery<List<LikeDto>>
    {
        public Guid TwithId { get; }
        
        public Guid CurrentUserId { get; }

        public GetTwithLikesQuery(int limit, int offset, Guid twithId, Guid currentUserId) : base(limit, offset)
        {
            TwithId = twithId;
            CurrentUserId = currentUserId;
        }
    }
    
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