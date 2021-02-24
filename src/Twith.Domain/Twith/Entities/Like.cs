using System;
using Twith.Domain.Common.Entities;
using Twith.Domain.Twith.ValueObjects;

namespace Twith.Domain.Twith.Entities
{
    public class Like : BaseEntity
    {
        public Guid Id { get; }

        public Twith Twith { get; }
        
        public Author Author { get; }

        protected Like()
        {
            
        }
        
        public Like(Guid id, Twith twith, Author author)
        {
            Id = id;
            Twith = twith;
            Author = author;
        }
    }
}