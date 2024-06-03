using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.Skills.Interfaces.Persistence;

public interface ISkillRepository
{
    Task<Skill> GetByIdAsync(UserId userId, SkillId skillId);
    Task<List<Skill>> GetAllAsync(UserId userId);
    Task AddAsync(Skill skill);
    Task UpdateAsync(Skill skill);
    Task DeleteAsync(Skill skill);
}