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
            [
                new Guid("b162b6c1-1572-48ee-8914-7da769335203"), 
            ],
            "https://google.com",
            false,
            DateTime.Now,
            false
        ),
        Advertisement.Create(
            "Software Engineer",
            "Facebook",
            "Software Engineer at Facebook",
            [
                new Guid("4f99f6e4-0d5b-4c8a-969a-2ace320a3f4a"),
                new Guid("b0a22d32-9d12-4920-a8ee-cae37255adb8"),
                new Guid("0ac99392-29e7-45c0-8a3e-4379a58220ab")
            ],
            "https://facebook.com",
            false,
            DateTime.Now,
            false
        ),
        Advertisement.Create(
            "Software Engineer",
            "Amazon",
            "Software Engineer at Amazon",
            [
                new Guid("4f99f6e4-0d5b-4c8a-969a-2ace320a3f4a"), 
                new Guid("843da3ca-c0cb-4644-9f3d-2ae35dc3762c")
            ],
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