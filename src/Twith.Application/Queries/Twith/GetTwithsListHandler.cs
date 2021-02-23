using System;
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
    public class GetTwithsListHandler : IRequestHandler<GetTwithsListQuery, List<TwithListViewDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetTwithsListHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<TwithListViewDto>> Handle(GetTwithsListQuery request, CancellationToken cancellationToken)
        {
            return _context.Twiths
                .OrderByDescending(t => t.CreatedAt)
                .Take(request.Limit)
                .Skip(request.Offset)
                .Select(t => new TwithListViewDto(
                    t.Id,
                    t.Content.Value,
                    (DateTime) t.CreatedAt,
                    new AuthorDto(t.Author),
                    EF.Property<int>(t, "_likesCount"),
                    _context.Likes.Any(l => l.Twith.Id == t.Id && l.Author.Id == request.CurrentUserId)           
                ))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}