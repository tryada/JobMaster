using JobMaster.Application.Authentication.Common;
using JobMaster.Application.Authentication.Interfaces;
using JobMaster.Application.Common.Persistence;
using JobMaster.Domain.Users;
using JobMaster.Domain.Users.Exceptions;
using MediatR;

namespace JobMaster.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtProvider tokenProvider,
    IPasswordProvider passwordProvider) : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = tokenProvider;
    private readonly IPasswordProvider _passwordprovider = passwordProvider;

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(command.Email) != null)
            throw new UserDuplicationException(command.Email);

        _passwordprovider.CreatePasswordHash(command.Password, out var passwordHash, out var passwordSalt);

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            passwordHash,
            passwordSalt);

        await _userRepository.AddAsync(user);

        var token = _jwtProvider.Generate(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}