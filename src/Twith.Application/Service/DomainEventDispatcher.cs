using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Twith.Domain.Common.Events;
using Twith.Domain.Common.Services;

namespace Twith.Application.Service
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            await _mediator.Publish(domainEvent);
        }

        public async Task Dispatch(IList<IDomainEvent> domainEvents)
        {
            await Task.WhenAll(domainEvents.Select(Dispatch));
        }
    }
}