using JobMaster.Domain.Users;

namespace JobMaster.Application.Common.Persistence;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(UserId id);
    Task<User?> GetByEmailAsync(string email);
}