using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Infrastructure.UnitTests.Advertisements.Utils;

public static class AdvertisementUtils
{
    public static Advertisement CreateAdvertisement(UserId? userId = null)
    {
        return Advertisement.Create(
            userId ?? UserId.CreateUnique(),
            "Title",
            "Company",
            "Description",
            "Url",
            false,
            null,
            false,
            [SkillId.CreateUnique()]);
    }

}