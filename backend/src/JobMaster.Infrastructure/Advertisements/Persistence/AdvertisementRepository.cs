using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Users;
using JobMaster.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace JobMaster.Infrastructure.Advertisements.Persistence;

public class AdvertisementRepository(JobMasterDbContext dbContext) : IAdvertisementRepository
{
    private readonly JobMasterDbContext _dbContext = dbContext;

    public async Task<Advertisement?> GetByIdAsync(UserId userId, AdvertisementId id)
    {
        return await _dbContext.Advertisements
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Advertisement>> GetAllAsync(UserId userId)
    {
        return await _dbContext.Advertisements
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Advertisement advertisement)
    {
        await _dbContext.Advertisements.AddAsync(advertisement);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Advertisement advertisement)
    {
        _dbContext.Advertisements.Update(advertisement);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Advertisement advertisement)
    {
        _dbContext.Advertisements.Remove(advertisement);
        return _dbContext.SaveChangesAsync();
    }
}