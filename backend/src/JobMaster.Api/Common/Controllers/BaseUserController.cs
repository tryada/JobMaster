using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MapsterMapper;
using MediatR;

namespace JobMaster.Api.Common.Controllers;

[ApiController]
[Authorize]
[Route("api/users/me/[controller]")]
public class BaseUserController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
    protected readonly IMapper _mapper = mapper;

    protected string UserId => 
        User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new UnauthorizedAccessException();
}