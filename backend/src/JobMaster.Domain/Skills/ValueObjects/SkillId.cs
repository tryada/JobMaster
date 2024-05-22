using JobMaster.Domain.Common.Models;

namespace JobMaster.Domain.Skills.ValueObjects;

public partial class SkillId : ValueObject
{
    public Guid Value { get; }

    private SkillId(Guid value)
    {
        Value = value;
    }
    
    private SkillId()
    {
    }
}