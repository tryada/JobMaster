using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.Shared.Utils;

public static class AdvertisementUtils
{
    public static Advertisement CreateDefault()
        => Advertisement.Create(
            UserId.CreateUnique(),
            "Title",
            "CompanyName",
            "Description",
            "Url",
            false,
            null,
            false,
            [SkillId.CreateUnique()]
        );
}