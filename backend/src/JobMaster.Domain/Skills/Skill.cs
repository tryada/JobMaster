using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Domain.Skills;

public partial class Skill
{
    public SkillId Id { get; private set; }
    public UserId UserId { get; private set; }
    public string Name { get; private set; }

    private Skill(
        UserId userId,
        SkillId id,
        string name)
    {
        UserId = userId;
        Id = id;
        Name = name;
    }

    private Skill()
    {
    }
}