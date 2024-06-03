using JobMaster.Domain.Common.Models.Interfaces;

namespace JobMaster.Domain.Common.Models;

public class Entity<T_Id> : IHasDomainEvent
    where T_Id : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public T_Id Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}