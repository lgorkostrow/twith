using System;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Dtos
{
    public record TwithDetailedViewDto
    {
        public Guid Id { get; }
        
        public string Content { get; }
        
        public DateTime CreatedAt { get; }
        
        public AuthorDto Author { get; }

        public TwithDetailedViewDto(Guid id, string content, DateTime createdAt, AuthorDto author)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            Author = author;
        }
    }
}