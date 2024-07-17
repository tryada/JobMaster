using JobMaster.Domain.Advertisements.Events;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Domain.Advertisements;

public partial class Advertisement
{
    public static Advertisement Create(
        UserId userId,
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected,
        bool replied,
        DateTime? replyDate,
        List<SkillId> skillIds)
    {
        var advertisement = new Advertisement(
            userId,
            AdvertisementId.CreateUnique(),
            title,
            companyName,
            description,
            url,
            applied,
            appliedDate,
            rejected,
            replied,
            replyDate,
            skillIds);

        advertisement.AddDomainEvent(new AdvertisementCreatedEvent(advertisement));

        return advertisement;
    }

    public void Update(
        string title,
        string companyName,
        string description,
        string url,
        bool applied,
        DateTime? appliedDate,
        bool rejected,
        bool replied,
        DateTime? replyDate,
        List<SkillId> skillIds)
    {
        Title = title;
        CompanyName = companyName;
        Description = description;
        Url = url;
        Applied = applied;
        AppliedDate = appliedDate;
        Rejected = rejected;
        Replied = replied;
        ReplyDate = replyDate;

        _skills.Clear();
        _skills.AddRange(skillIds);

        AddDomainEvent(new AdvertisementUpdatedEvent(this));
    }
}