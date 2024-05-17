using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Queries.ListSkills;
using JobMaster.Contracts.Skills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Skills.Controllers;

public class SkillsController : BaseController
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var query = new ListSkillsQuery();
        var queryResult = _mediator.Send(query);

        var result = queryResult.Result.Select(x => new SkillResponse(
            x.Id.ToString(), 
            x.Name
        )).ToList();
    
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(CreateSkillRequest request)
    {
        var command = new CreateSkillCommand(request.Name);
        var commandResult = _mediator.Send(command);

        var result = new SkillResponse(
            commandResult.Result.Id.ToString(),
            commandResult.Result.Name
        );

        return Ok(result);
    }
}