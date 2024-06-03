using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Advertisements.Events.Interfaces;
using JobMaster.Domain.Skills.ValueObjects;
using MediatR;

namespace JobMaster.Application.Skills.Events.Base;

public class AdvertisementDataIntegrityEventHandler<T>(ISkillRepository skillRepository) 
    : INotificationHandler<T>
    where T : IAdvertisementEvent
{
    private readonly ISkillRepository _skillRepository = skillRepository;

    public async Task Handle(T notification, CancellationToken cancellationToken)
    {
        List<SkillId> advertisementSkillIds = [.. notification.Advertisement.Skills];
        var skills = await _skillRepository.GetValidIdsByIdsAsync(notification.Advertisement.UserId, advertisementSkillIds);

        if (!advertisementSkillIds.TrueForAll(skills.Contains))
        {
            var error = "Invalid data integrity. Advertisement skills do not match user skills.";
            throw new InvalidOperationException(error);
        }
    }
}