using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Domain.Advertisements;

public partial class Advertisement
{
    private readonly List<SkillId> _skills = [];

    public AdvertisementId Id { get; private set; }
    public string Title { get; private set; }
    public string CompanyName { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<SkillId> Skills => _skills.AsReadOnly();
    public string Url { get; private set; }
    public bool Applied { get; private set; }
    public DateTime? AppliedDate { get; private set; }
    public bool Rejected { get; private set; }
    
    private Advertisement(
        AdvertisementId id,
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected)
    {
        Id = id;
        Title = title;
        CompanyName = companyName;
        Description = description;
        Url = url;
        Applied = applied;
        AppliedDate = appliedDate;
        Rejected = rejected;
    }

    private Advertisement()
    {
    }
}