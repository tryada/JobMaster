using FluentAssertions;

using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Domain.Advertisements;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement.Utils;

public static class CreateAdvertisementCommandUtils
{
    public static CreateAdvertisementCommand CreateValidCommand()
        => new CreateAdvertisementCommandBuilder().Build();
    public static CreateAdvertisementCommand CreateInvalidCommandWithEmptyTitle()
        => new CreateAdvertisementCommandBuilder().OverrideTitle(title: string.Empty).Build();
    public static CreateAdvertisementCommand CreateInvalidCommandWithEmptyCompanyName()
        => new CreateAdvertisementCommandBuilder().OverrideCompanyName(companyName: string.Empty).Build();
    public static CreateAdvertisementCommand CreateInvalidCommandWithEmptyUrl()
        => new CreateAdvertisementCommandBuilder().OverrideUrl(url: string.Empty).Build();

    public static void Assert(CreateAdvertisementCommand command, Advertisement result)
    {
        result.Should().NotBeNull();
        result.Id.Should().NotBeNull();
        result.Title.Should().Be(command.Title);
        result.CompanyName.Should().Be(command.CompanyName);
        result.Description.Should().Be(command.Description);
        result.Skills.Should().BeEquivalentTo(command.Skills);
        result.Url.Should().Be(command.Url);
        result.Applied.Should().BeFalse();
        result.AppliedDate.Should().BeNull();
        result.Rejected.Should().BeFalse();
    }
}