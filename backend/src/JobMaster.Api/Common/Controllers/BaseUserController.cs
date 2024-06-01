using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Common.Controllers;

[ApiController]
[Authorize]
[Route("api/users/{userId}/[controller]")]
public class BaseUserController : ControllerBase
{
}