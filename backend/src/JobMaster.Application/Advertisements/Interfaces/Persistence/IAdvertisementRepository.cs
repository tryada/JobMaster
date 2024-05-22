using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;

namespace JobMaster.Application.Advertisements.Interfaces.Persistence;

public interface IAdvertisementRepository
{
    Task<Advertisement> GetByIdAsync(AdvertisementId id);
    Task<List<Advertisement>> GetAllAsync();
    Task AddAsync(Advertisement advertisement);
    Task UpdateAsync(Advertisement advertisement);
    Task DeleteAsync(Advertisement advertisement);
}