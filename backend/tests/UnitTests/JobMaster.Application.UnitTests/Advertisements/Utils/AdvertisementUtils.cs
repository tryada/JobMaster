using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Utils;

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

    public static Advertisement CreateWithUserId(UserId userId)
        => Advertisement.Create(
            userId,
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