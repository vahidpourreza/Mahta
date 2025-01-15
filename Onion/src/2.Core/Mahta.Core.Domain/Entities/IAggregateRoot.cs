using Mahta.Core.Domain.Events;

namespace Mahta.Core.Domain.Entities;


public interface IAggregateRoot
{
    void ClearEvents();
    IEnumerable<IDomainEvent> GetEvents();
}