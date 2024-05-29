using JobMaster.Application.Authentication.Common;
using MediatR;

namespace JobMaster.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;