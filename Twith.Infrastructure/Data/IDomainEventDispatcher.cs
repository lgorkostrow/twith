using System.Collections.Generic;
using System.Threading.Tasks;
using Twith.Domain.Common.Events;

namespace Twith.Infrastructure.Data
{
    public interface IDomainEventDispatcher
    {
        public Task Dispatch(IDomainEvent domainEvent);
        
        public Task Dispatch(IList<IDomainEvent> domainEvents);
    }
}