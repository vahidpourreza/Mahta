using Mahta.Core.Domain.Events;

namespace Mahta.Core.Contracts.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}