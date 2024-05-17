using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;

namespace JobMaster.Infrastructure.Advertisements.Persistence;

public class AdvertisementRepository : IAdvertisementRepository
{
    private static readonly List<Advertisement> advertisements =
    [
        Advertisement.Create(
            "Software Engineer",
            "Google",
            "Software Engineer at Google",
            [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()],
            "https://google.com",
            false,
            DateTime.Now,
            false
        ),
        Advertisement.Create(
            "Software Engineer",
            "Facebook",
            "Software Engineer at Facebook",
            [Guid.NewGuid()],
            "https://facebook.com",
            false,
            DateTime.Now,
            false
        ),
        Advertisement.Create(
            "Software Engineer",
            "Amazon",
            "Software Engineer at Amazon",
            [Guid.NewGuid(), Guid.NewGuid()],
            "https://amazon.com",
            false,
            DateTime.Now,
            false
        )
    ];

    public async Task<Advertisement> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(advertisements.FirstOrDefault(x => x.Id == id));
    }

    public async Task<List<Advertisement>> GetAllAsync()
    {
        return await Task.FromResult(advertisements.ToList());
    }

    public Task AddAsync(Advertisement advertisement)
    {
        advertisements.Add(advertisement);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Advertisement advertisement)
    {
        var existingAdvertisement = advertisements.FirstOrDefault(x => x.Id == advertisement.Id);
        if (existingAdvertisement != null)
        {
            advertisements.Remove(existingAdvertisement);
            advertisements.Add(advertisement);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Advertisement advertisement)
    {
        var existingAdvertisement = advertisements.FirstOrDefault(x => x.Id == advertisement.Id);
        if (existingAdvertisement != null)
        {
            advertisements.Remove(existingAdvertisement);
        }

        return Task.CompletedTask;
    }
}