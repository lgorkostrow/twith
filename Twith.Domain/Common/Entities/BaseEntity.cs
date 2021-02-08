using System;

namespace Twith.Domain.Common.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        protected BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
    }
}