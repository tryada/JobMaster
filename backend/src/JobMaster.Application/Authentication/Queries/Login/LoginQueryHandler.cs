using JobMaster.Application.Authentication.Common;
using JobMaster.Application.Authentication.Interfaces;
using JobMaster.Application.Common.Persistence;
using JobMaster.Domain.Authentication.Exceptions;
using MediatR;

namespace JobMaster.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IPasswordProvider passwordProvider,
    IJwtProvider jwtProvider) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordProvider _passwordProvider = passwordProvider;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(query.Email) 
            ?? throw new InvalidCredentialsException();

        if (_passwordProvider.VerifyPassword(query.Password, user.PasswordHash, user.PasswordSalt) is false)
            throw new InvalidCredentialsException();

        return new AuthenticationResult(
            user,
            _jwtProvider.Generate(user, out var expirationDate),
            expirationDate
        );
    }
}