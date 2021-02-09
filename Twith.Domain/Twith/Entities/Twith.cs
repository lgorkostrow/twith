using System;
using Twith.Domain.Common.Entities;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Entities
{
    public class Twith : BaseEntity
    {
        public Guid Id { get; }
        
        public Author Author { get; }
        
        public Content Content { get; }

        private Twith()
        {
        }

        public Twith(Guid id, Author author, Content content)
        {
            Id = id;
            Author = author;
            Content = content;
        }
    }
}