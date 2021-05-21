using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Twith.Domain.Twith.Dtos;
using Twith.Infrastructure.Data;

namespace Twith.Application.Queries.Twith
{
    public record GetTwithQuery : IRequest<TwithDetailedViewDto>
    {
        public Guid Id { get; }
        
        public Guid CurrentUserId { get; }

        public GetTwithQuery(Guid id, Guid currentUserId)
        {
            Id = id;
            CurrentUserId = currentUserId;
        }
    }
    
    public class GetTwithHandler : IRequestHandler<GetTwithQuery, TwithDetailedViewDto>
    {
        private readonly ApplicationDbContext _context;

        public GetTwithHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<TwithDetailedViewDto> Handle(GetTwithQuery request, CancellationToken cancellationToken)
        {
            return _context.Twiths.Where(t => t.Id == request.Id)
                .Select(t => new TwithDetailedViewDto(
                    t.Id,
                    t.Content.Value,
                    (DateTime) t.CreatedAt,
                    new AuthorDto(t.Author),
                    EF.Property<int>(t, "_likesCount"),
                    _context.Likes.Any(l => l.Twith.Id == t.Id && l.Author.Id == request.CurrentUserId)
                ))
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}