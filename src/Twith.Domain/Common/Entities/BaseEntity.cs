using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Twith.Domain.Common.Events;

namespace Twith.Domain.Common.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; }
        
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public IList<IDomainEvent> DomainEvents { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            DomainEvents = new List<IDomainEvent>();
        }

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }

        public IList<IDomainEvent> PopEvents()
        {
            var events = DomainEvents;
            DomainEvents = new List<IDomainEvent>();
            
            return events;
        }
    }
}