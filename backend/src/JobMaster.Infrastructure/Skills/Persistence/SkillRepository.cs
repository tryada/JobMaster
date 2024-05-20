using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;

namespace JobMaster.Infrastructure.Skills.Persistence;

public class SkillRepository : ISkillRepository
{
    private static readonly List<Skill> Skills = 
    [
        new(new Guid("b162b6c1-1572-48ee-8914-7da769335203"), "C#"),
        new(new Guid("0ac99392-29e7-45c0-8a3e-4379a58220ab"), "Java"),
        new(new Guid("32fb6ce3-a88d-4aaf-a8b9-c1948cc75821"), "Python"),
        new(new Guid("b0a22d32-9d12-4920-a8ee-cae37255adb8"), "JavaScript"),
        new(new Guid("843da3ca-c0cb-4644-9f3d-2ae35dc3762c"), "TypeScript"),
        new(new Guid("4f99f6e4-0d5b-4c8a-969a-2ace320a3f4a"), "SQL"),
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