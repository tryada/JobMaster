using JobMaster.Domain.Common.Models.Interfaces;

namespace JobMaster.Domain.Advertisements.Events.Interfaces;

public interface IAdvertisementEvent : IDomainEvent
{
    Advertisement Advertisement { get; }
}