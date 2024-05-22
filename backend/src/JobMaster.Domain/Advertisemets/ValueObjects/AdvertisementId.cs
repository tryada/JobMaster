using JobMaster.Domain.Common.Models;

namespace JobMaster.Domain.Advertisements.ValueObjects;

public partial class AdvertisementId : ValueObject
{
    public Guid Value { get; }

    private AdvertisementId(Guid value)
    {
        Value = value;
    }

    private AdvertisementId()
    {
    }
}