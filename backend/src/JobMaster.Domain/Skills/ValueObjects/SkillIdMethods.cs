using JobMaster.Domain.Common.Models;

namespace JobMaster.Domain.Skills.ValueObjects;

public partial class SkillId : ValueObject
{
    public static SkillId CreateUnique() => new(Guid.NewGuid());
    public static SkillId Create(string value) => new(new Guid(value));

    public override string ToString() => Value.ToString();
    
    public static explicit operator Guid(SkillId self) => self.Value;

    public static explicit operator SkillId(Guid value) => new(value);
}