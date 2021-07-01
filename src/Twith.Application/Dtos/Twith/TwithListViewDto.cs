using System;
using Twith.Domain.Common.ValueObjects;

namespace Twith.Application.Dtos.Twith
{
    public record TwithListViewDto : BaseValueObject
    {
        public Guid Id { get; }
                
        public string Content { get; }
                
        public DateTime CreatedAt { get; }
                
        public AuthorDto Author { get; }
        
        public int LikesCount { get; }
        
        public bool Liked { get; }
        
        public TwithListViewDto(Guid id, string content, DateTime createdAt, AuthorDto author, int likesCount, bool liked)
        {
            Id = id;
            Content = content;
            CreatedAt = createdAt;
            Author = author;
            LikesCount = likesCount;
            Liked = liked;
        }
    }
}