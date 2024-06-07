using JobMaster.Domain.Skills.Events;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Domain.Skills;

public partial class Skill 
{
    public static Skill Create(
        UserId userId,
        string name)
    {
        return new Skill(
            userId,
            SkillId.CreateUnique(), 
            name);
    }

    public void Update(string name) 
    {
        Name = name;
    }

    public void Delete() 
    {
        AddDomainEvent(new SkillDeletedEvent(this));
    }
}