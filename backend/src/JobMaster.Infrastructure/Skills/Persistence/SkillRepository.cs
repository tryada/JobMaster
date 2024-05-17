using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;

namespace JobMaster.Infrastructure.Skills.Persistence;

public class SkillRepository : ISkillRepository
{
    private static readonly List<Skill> Skills = 
    [
        new(Guid.NewGuid(), "C#"),
        new(Guid.NewGuid(), "Java"),
        new(Guid.NewGuid(), "Python"),
        new(Guid.NewGuid(), "JavaScript"),
        new(Guid.NewGuid(), "TypeScript"),
        new(Guid.NewGuid(), "SQL"),
    ];

    public Task<List<Skill>> GetAllAsync()
    {
        return Task.FromResult(Skills);
    }

    public Task AddAsync(Skill skill)
    {
        Skills.Add(skill);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Skill skill)
    {
        var existingSkill = Skills.FirstOrDefault(x => x.Id == skill.Id);
        if (existingSkill != null)
        {
            Skills.Remove(existingSkill);
            Skills.Add(skill);
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Skill skill)
    {
        var existingSkill = Skills.FirstOrDefault(x => x.Id == skill.Id);
        if (existingSkill != null)
        {
            Skills.Remove(existingSkill);
        }

        return Task.CompletedTask;
    }

}