using System;
using MediatR;

namespace Twith.Domain.Twith.Commands
{
    public record CreateTwithCommand : IRequest
    {
        public Guid Id { get; }
        
        public string Content { get; }
        
        public Guid AuthorId { get; }

        public CreateTwithCommand(Guid id, string content, Guid authorId)
        {
            Id = id;
            Content = content;
            AuthorId = authorId;
        }
    }
}