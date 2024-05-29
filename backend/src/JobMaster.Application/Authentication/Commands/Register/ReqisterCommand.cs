using JobMaster.Application.Authentication.Common;
using MediatR;

namespace JobMaster.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResult>;