namespace JobMaster.Domain.Users;

public partial class User
{
    public UserId Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        byte[] passwordHash,
        byte[] passwordSalt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    private User()
    {
    }
}