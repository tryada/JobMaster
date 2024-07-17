using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement.Utils;

public class UpdateAdvertisementCommandBuilder
{
    private UserId _userId;
    private AdvertisementId _id;
    private string _title;
    private string _companyName;
    private string _description;
    private List<SkillId> _skills;
    private string _url;
    private bool _applied;
    private DateTime? _appliedDate;
    private bool _rejected;
    private bool _replied;
    private DateTime _replyDate;

    public UpdateAdvertisementCommandBuilder(bool setDefaultValues = true)
    {
        if (setDefaultValues)
            SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        _userId = UserId.CreateUnique();
        _id = AdvertisementId.CreateUnique();
        _title = "Title";
        _companyName = "CompanyName";
        _description = "Description";
        _skills = [SkillId.CreateUnique()];
        _url = "Url";
        _applied = false;
        _appliedDate = null;
        _rejected = false;
        _replied = false;
        _replyDate = DateTime.Now;
    }

    public UpdateAdvertisementCommandBuilder WithUserId(UserId userId)
    {
        _userId = userId;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithId(AdvertisementId id)
    {
        _id = id;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithCompanyName(string companyName)
    {
        _companyName = companyName;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithSkills(List<SkillId> skills)
    {
        _skills = skills;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithApplied(bool applied)
    {
        _applied = applied;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithAppliedDate(DateTime? appliedDate)
    {
        _appliedDate = appliedDate;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithRejected(bool rejected)
    {
        _rejected = rejected;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithReplied(bool replied)
    {
        _replied = replied;
        return this;
    }

    public UpdateAdvertisementCommandBuilder WithReplyDate(DateTime replyDate)
    {
        _replyDate = replyDate;
        return this;
    }

    public UpdateAdvertisementCommand Build()
    {
        return new UpdateAdvertisementCommand(
            UserId: _userId,
            Id: _id,
            Title: _title,
            CompanyName: _companyName,
            Description: _description,
            Skills: _skills,
            Url: _url,
            Applied: _applied,
            AppliedDate: _appliedDate,
            Rejected: _rejected,
            Replied: _replied,
            ReplyDate: _replyDate);
    }
}