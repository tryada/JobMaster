using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Domain.Advertisements;

public partial class Advertisement
{
    public static Advertisement Create(
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected)
    {
        return new Advertisement(
            AdvertisementId.CreateUnique(),
            title,
            companyName,
            description,
            url,
            applied,
            appliedDate,
            rejected);
    }

    public void Update(
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected)
    {
        Title = title;
        CompanyName = companyName;
        Description = description;
        Url = url;
        Applied = applied;
        AppliedDate = appliedDate;
        Rejected = rejected;
    }

    public void AddSkills(List<SkillId> skillIds)
    {
        _skills.AddRange(skillIds);
    }

    public void UpdateSkills(List<SkillId> skillIds)
    {
        _skills.Clear();
        _skills.AddRange(skillIds);
    }
}