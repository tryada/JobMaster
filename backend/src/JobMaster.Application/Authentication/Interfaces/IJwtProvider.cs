using JobMaster.Domain.Users;

namespace JobMaster.Application.Authentication.Interfaces;

public interface IJwtProvider 
{
    string Generate(User user, out DateTime expirationDate);
}