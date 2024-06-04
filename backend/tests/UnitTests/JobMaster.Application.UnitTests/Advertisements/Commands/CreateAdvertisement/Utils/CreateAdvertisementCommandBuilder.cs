using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement.Utils;

public class CreateAdvertisementCommandBuilder
{
    private string _title;
    private string _companyName;
    private string _url;

    public CreateAdvertisementCommandBuilder()
    {
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        _title = "Title";
        _companyName = "CompanyName";
        _url = "Url";
    }

    public CreateAdvertisementCommandBuilder OverrideTitle(string title)
    {
        _title = title;
        return this;
    }

    public CreateAdvertisementCommandBuilder OverrideCompanyName(string companyName)
    {
        _companyName = companyName;
        return this;
    }

    public CreateAdvertisementCommandBuilder OverrideUrl(string url)
    {
        _url = url;
        return this;
    }

    public CreateAdvertisementCommand Build()
    {
        return new CreateAdvertisementCommand(
            UserId.CreateUnique(),
            _title,
            _companyName,
            "Description",
            [SkillId.CreateUnique()],
            _url,
            false,
            null,
            false);
    }
}