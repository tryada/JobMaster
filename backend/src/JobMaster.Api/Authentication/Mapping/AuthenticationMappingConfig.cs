using JobMaster.Application.Authentication.Commands.Register;
using JobMaster.Application.Authentication.Common;
using JobMaster.Application.Authentication.Queries.Login;
using JobMaster.Contracts.Authentication;
using Mapster;

namespace JobMaster.Api.Authentication.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<RegisterRequest, RegisterCommand>();
        config.ForType<LoginRequest, LoginQuery>();

        config.ForType<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}