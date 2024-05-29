namespace JobMaster.Application.Authentication.Interfaces;

public interface IPasswordProvider
{
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
}