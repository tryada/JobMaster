using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Application.Skills.Interfaces.Persistence
{
    public interface ISkillRepository
    {
        Task<Skill> GetByIdAsync(SkillId skillId);
        Task<List<Skill>> GetAllAsync();
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
    }
}