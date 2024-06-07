using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Skills.Events;
using MediatR;

namespace JobMaster.Application.Advertisements.Events;

public class SkillDeletedEventHandler(IAdvertisementRepository advertisementRepository) 
    : INotificationHandler<SkillDeletedEvent>
{
    private readonly IAdvertisementRepository _advertisementRepository = advertisementRepository;

    public async Task Handle(SkillDeletedEvent notification, CancellationToken cancellationToken)
    {
        if (await _advertisementRepository.IsSkillUsed(notification.Skill.Id))
        {
            var error = "Cannot delete skill. It is being used by one or more advertisements.";
            throw new InvalidOperationException(error);
        }
    }
}