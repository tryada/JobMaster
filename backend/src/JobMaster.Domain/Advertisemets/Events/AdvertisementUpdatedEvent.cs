using JobMaster.Domain.Advertisements.Events.Interfaces;

namespace JobMaster.Domain.Advertisements.Events;

public record AdvertisementUpdatedEvent(
    Advertisement Advertisement) 
    : IAdvertisementEvent;