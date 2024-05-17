using JobMaster.Domain.Skills;

namespace JobMaster.Application.Skills.Interfaces.Persistence
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
    }
}