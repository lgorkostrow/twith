using System;
using Twith.Domain.Twith.Entities;

namespace Twith.Application.Dtos.Twith
{
    public record LikeDto : BaseDto
    {
        public Guid Id { get; }
        
        public AuthorDto Author { get;}

        public LikeDto(Guid id, AuthorDto author)
        {
            Id = id;
            Author = author;
        }

        public LikeDto(Like like): this(like.Id, new AuthorDto(like.Author))
        {
        }
    }
}