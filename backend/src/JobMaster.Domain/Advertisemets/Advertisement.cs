using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Common.Models;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Domain.Advertisements;

public partial class Advertisement : Entity<AdvertisementId>
{
    private readonly List<SkillId> _skills = [];

    public UserId UserId { get; private set; }
    public string Title { get; private set; }
    public string CompanyName { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyList<SkillId> Skills => _skills.AsReadOnly();
    public string Url { get; private set; }
    public bool Applied { get; private set; }
    public DateTime? AppliedDate { get; private set; }
    public bool Rejected { get; private set; }
    
    private Advertisement(
        UserId userId,
        AdvertisementId id,
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected,
        List<SkillId> skillIds)
    {
        UserId = userId;
        Id = id;
        Title = title;
        CompanyName = companyName;
        Description = description;
        Url = url;
        Applied = applied;
        AppliedDate = appliedDate;
        Rejected = rejected;
        _skills.AddRange(skillIds);
    }

    private Advertisement()
    {
    }
}