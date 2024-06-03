using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using JobMaster.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace JobMaster.Infrastructure.Skills.Persistence;

public class SkillRepository(JobMasterDbContext dbContext) : ISkillRepository
{
    private readonly JobMasterDbContext _dbContext = dbContext;

    public async Task<Skill> GetByIdAsync(UserId userId, SkillId id)
    {
        return await _dbContext.Skills
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Skill>> GetAllAsync(UserId userId)
    {
        return await _dbContext.Skills
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(Skill skill)
    {
        await _dbContext.Skills.AddAsync(skill);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Skill skill)
    {
        _dbContext.Skills.Update(skill);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Skill skill)
    {
        _dbContext.Skills.Remove(skill);
        return _dbContext.SaveChangesAsync();
    }
}