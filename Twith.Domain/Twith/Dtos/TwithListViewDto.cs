using System;

namespace Twith.Domain.Twith.Dtos
{
    public record TwithListViewDto
    {
        public Guid Id { get; }
                
        public string Content { get; }
                
        public DateTime CreatedAt { get; }
                
        public AuthorDto Author { get; }
        
        public bool Liked { get; }
        
        public TwithListViewDto(Guid id, string content, DateTime createdAt, AuthorDto author, bool liked)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            Author = author;
            Liked = liked;
        }
    }
}