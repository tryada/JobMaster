using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Queries.ListSkills;
using JobMaster.Contracts.Skills;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Skills.Controllers;

public class SkillsController(IMediator mediator, IMapper mapper) : BaseController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public IActionResult Get()
    {
        var query = new ListSkillsQuery();
        var queryResult = _mediator.Send(query);

        var result = _mapper.Map<IEnumerable<SkillResponse>>(queryResult.Result);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(CreateSkillRequest request)
    {
        var command = new CreateSkillCommand(request.Name);
        var commandResult = _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult.Result);
        return Ok(result);
    }
}