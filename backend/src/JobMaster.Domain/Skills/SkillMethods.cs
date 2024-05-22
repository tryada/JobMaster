using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Domain.Skills;

public partial class Skill 
{
    public static Skill Create(string name)
    {
        return new Skill(SkillId.CreateUnique(), name);
    }
}