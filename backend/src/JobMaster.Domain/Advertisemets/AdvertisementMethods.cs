namespace JobMaster.Domain.Advertisements;

public partial class Advertisement
{
    public static Advertisement Create(
        string title,
        string companyName,
        string description,
        List<Guid> skills,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected)
    {
        return new Advertisement(
            Guid.NewGuid(),
            title,
            companyName,
            description,
            skills,
            url,
            applied,
            appliedDate,
            rejected);
    }

    public void Update(
        string title,
        string companyName,
        string description,
        List<Guid> skills,
        string url,
        bool applied,
        DateTime appliedDate,
        bool rejected)
    {
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