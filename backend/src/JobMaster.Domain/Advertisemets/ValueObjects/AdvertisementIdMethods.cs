namespace JobMaster.Domain.Advertisements.ValueObjects;

public partial class AdvertisementId
{
    public static AdvertisementId CreateUnique() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();

    public static explicit operator Guid(AdvertisementId self) => self.Value;

    public static explicit operator AdvertisementId(Guid value) => new(value);
}