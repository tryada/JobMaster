using JobMaster.Domain.Users;

namespace JobMaster.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);