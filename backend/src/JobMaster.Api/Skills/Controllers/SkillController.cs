using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Commands.UpdateSkill;
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
    public async Task<IActionResult> Get()
    {
        var query = new ListSkillsQuery();
        var queryResult = await _mediator.Send(query);

        var result = _mapper.Map<IEnumerable<SkillResponse>>(queryResult);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSkillRequest request)
    {
        var command = _mapper.Map<CreateSkillCommand>(request);
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, UpdateSkillRequest request)
    {
        var command = _mapper.Map<UpdateSkillCommand>((request, id));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }
}