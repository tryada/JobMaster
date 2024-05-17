using JobMaster.Domain.Advertisements;

namespace JobMaster.Application.Advertisements.Interfaces.Persistence;

public interface IAdvertisementRepository
{
    Task<List<Advertisement>> GetAllAsync();
    Task AddAsync(Advertisement advertisement);
    Task UpdateAsync(Advertisement advertisement);
    Task DeleteAsync(Advertisement advertisement);
}