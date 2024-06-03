namespace JobMaster.Domain.Common.Models.Interfaces;

public interface IHasDomainEvent
{
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    public void AddDomainEvent(IDomainEvent domainEvent);
    public void ClearDomainEvents();
}