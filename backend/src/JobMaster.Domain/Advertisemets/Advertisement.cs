namespace JobMaster.Domain.Advertisements;

public class Advertisement 
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string CompanyName { get; private set; }
    public string Description { get; private set; }
    public List<Guid> Skills { get; private set; }
    public string Url { get; private set; }
    public bool Applied { get; private set; }
    public DateTime AppliedDate { get; private set; }
    public bool Rejected { get; private set; }
    
    public Advertisement(
        string title,
        string companyName,
        string description,
        List<Guid> skills,
        string url,
        bool applied,
        DateTime appliedDate,
        bool rejected)
    {
        Id = Guid.NewGuid();
        Title = title;
        CompanyName = companyName;
        Description = description;
        Skills = skills;
        Url = url;
        Applied = applied;
        AppliedDate = appliedDate;
        Rejected = rejected;
    }
}