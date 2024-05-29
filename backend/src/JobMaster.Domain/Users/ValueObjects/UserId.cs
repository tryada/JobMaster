using JobMaster.Domain.Common.Models;

namespace JobMaster.Domain.Users;

public partial class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }
    
    private UserId()
    {
    }
}