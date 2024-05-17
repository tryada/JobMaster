namespace JobMaster.Domain.Skills;

public class Skill
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Skill(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}