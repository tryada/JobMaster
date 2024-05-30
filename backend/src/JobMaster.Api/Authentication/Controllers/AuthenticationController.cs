using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Authentication.Commands.Register;
using JobMaster.Application.Authentication.Common;
using JobMaster.Application.Authentication.Queries.Login;
using JobMaster.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Authentication.Controllers;

[AllowAnonymous]
public class AuthenticationController(ISender sender, IMapper mapper) : BaseController
{
    private readonly ISender _sender = sender;
    private readonly IMapper _mapper = mapper;

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginRequest, LoginQuery>(request);
        var response = await _sender.Send(query);
        return Ok(_mapper.Map<AuthenticationResult, AuthenticationResponse>(response));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request) 
    {
        var command = _mapper.Map<RegisterRequest, RegisterCommand>(request);
        var response = await _sender.Send(command);
        return Ok(_mapper.Map<AuthenticationResult, AuthenticationResponse>(response));
    }
}