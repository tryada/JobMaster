using FluentAssertions;

using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills.ValueObjects;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement.Utils;

public static class UpdateAdvertisementCommandUtils
{
    public static UpdateAdvertisementCommand CreateCommand(
        Advertisement advertisement,
        string title,
        string companyName,
        string description,
        List<SkillId> skills,
        string url,
        bool applied,
        DateTime appliedDate,
        bool rejected)
    {
        return new UpdateAdvertisementCommandBuilder(false)
            .WithId(advertisement.Id)
            .WithUserId(advertisement.UserId)
            .WithTitle(title)
            .WithCompanyName(companyName)
            .WithDescription(description)
            .WithSkills(skills)
            .WithUrl(url)
            .WithApplied(applied)
            .WithAppliedDate(appliedDate)
            .WithRejected(rejected)
            .Build();
    }

    public static UpdateAdvertisementCommand CreateValidCommand()
        => new UpdateAdvertisementCommandBuilder().Build();
    public static UpdateAdvertisementCommand CreateInvalidCommandWithEmptyTitle()
        => new UpdateAdvertisementCommandBuilder().WithTitle(string.Empty).Build();
    public static UpdateAdvertisementCommand CreateInvalidCommandWithEmptyCompanyName()
        => new UpdateAdvertisementCommandBuilder().WithCompanyName(string.Empty).Build();
    public static UpdateAdvertisementCommand CreateInvalidCommandWithEmptyUrl()
        => new UpdateAdvertisementCommandBuilder().WithUrl(string.Empty).Build();

    public static void Assert(UpdateAdvertisementCommand command, Advertisement result)
    {
        result.Should().NotBeNull();
        result.Id.Should().Be(command.Id);
        result.Title.Should().Be(command.Title);
        result.CompanyName.Should().Be(command.CompanyName);
        result.Description.Should().Be(command.Description);
        result.Url.Should().Be(command.Url);
        result.Applied.Should().Be(command.Applied);
        result.Skills.Should().BeEquivalentTo(command.Skills);
    }
}