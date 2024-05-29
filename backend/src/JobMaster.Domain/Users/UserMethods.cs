namespace JobMaster.Domain.Users;

public partial class User
{
    public static User Create(
        string firstName,
        string lastName,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt)
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            passwordHash,
            passwordSalt);
    }
}