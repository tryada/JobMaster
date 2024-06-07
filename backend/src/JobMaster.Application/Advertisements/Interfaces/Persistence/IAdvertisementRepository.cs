using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.Advertisements.Interfaces.Persistence;

public interface IAdvertisementRepository
{
    Task<Advertisement?> GetByIdAsync(UserId userId, AdvertisementId id);
    Task<List<Advertisement>> GetAllAsync(UserId userId);
    Task AddAsync(Advertisement advertisement);
    Task UpdateAsync(Advertisement advertisement);
    Task DeleteAsync(Advertisement advertisement);
    Task<bool> IsSkillUsed(SkillId skillId);
}