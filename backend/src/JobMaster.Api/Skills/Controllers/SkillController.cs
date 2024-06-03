using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;

using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Commands.UpdateSkill;
using JobMaster.Application.Skills.Queries.ListSkills;
using JobMaster.Contracts.Skills;

namespace JobMaster.Api.Skills.Controllers;

public class SkillsController(IMediator mediator, IMapper mapper) 
    : BaseUserController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> Get(string userId)
    {
        var query = _mapper.Map<ListSkillsQuery>(userId);
        var queryResult = await _mediator.Send(query);

        var result = _mapper.Map<IEnumerable<SkillResponse>>(queryResult);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSkillRequest request, string userId)
    {
        var command = _mapper.Map<CreateSkillCommand>((request, userId));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateSkillRequest request, string userId, string id)
    {
        var command = _mapper.Map<UpdateSkillCommand>((request, userId, id));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }
}