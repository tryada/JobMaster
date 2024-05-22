using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Domain.Skills;

public partial class Skill
{
    public SkillId Id { get; private set; }
    public string Name { get; private set; }

    private Skill(SkillId id, string name)
    {
        Id = id;
        Name = name;
    }

    private Skill()
    {
    }
}