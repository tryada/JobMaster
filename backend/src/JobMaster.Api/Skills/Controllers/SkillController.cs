using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;

using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Commands.UpdateSkill;
using JobMaster.Application.Skills.Queries.ListSkills;
using JobMaster.Application.Skills.Commands.DeleteSkill;
using JobMaster.Contracts.Skills;

namespace JobMaster.Api.Skills.Controllers;

public class SkillsController(IMediator mediator, IMapper mapper) 
    : BaseUserController(mediator, mapper)
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = _mapper.Map<ListSkillsQuery>(UserId);
        var queryResult = await _mediator.Send(query);

        var result = _mapper.Map<IEnumerable<SkillResponse>>(queryResult);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSkillRequest request)
    {
        var command = _mapper.Map<CreateSkillCommand>((request, UserId));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateSkillRequest request, string id)
    {
        var command = _mapper.Map<UpdateSkillCommand>((request, UserId, id));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<SkillResponse>(commandResult);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = _mapper.Map<DeleteSkillCommand>((UserId, id));
        await _mediator.Send(command);

        return NoContent();
    }
}