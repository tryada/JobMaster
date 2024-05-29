using JobMaster.Domain.Common.Models;

namespace JobMaster.Domain.Users;

public partial class UserId : ValueObject
{
    public static UserId CreateUnique() => new(Guid.NewGuid());
    public static UserId Create(string value) => new(new Guid(value));
    public static UserId Create(Guid guid) => new(guid);
}