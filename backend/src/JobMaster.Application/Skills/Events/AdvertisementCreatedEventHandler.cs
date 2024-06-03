using JobMaster.Application.Skills.Events.Base;
using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Advertisements.Events;

namespace JobMaster.Application.Skills.Events;

public class AdvertisementCreatedEventHandler(ISkillRepository skillRepository) 
    : AdvertisementDataIntegrityEventHandler<AdvertisementCreatedEvent>(skillRepository)
{
}