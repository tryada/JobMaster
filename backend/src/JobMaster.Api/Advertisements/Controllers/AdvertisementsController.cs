using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using MediatR;

using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;
using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.Advertisements.Queries.GetAdvertisement;
using JobMaster.Application.Advertisements.Queries.ListAdvertisements;
using JobMaster.Contracts.Advertisements;

namespace JobMaster.Api.Advertisements.Controllers;

public class AdvertisementsController(IMediator mediator, IMapper mapper) 
    : BaseUserController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string userId, string id)
    {
        var query = _mapper.Map<GetAdvertisementQuery>((userId, id));
        var queryResult = await _mediator.Send(query);

        var result = _mapper.Map<AdvertisementResponse>(queryResult);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get(string userId)
    {
        var query = _mapper.Map<ListAdvertisementsQuery>(userId);
        var queryResult = await _mediator.Send(query);
        
        var result = _mapper.Map<IEnumerable<AdvertisementResponse>>(queryResult);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAdvertisementRequest request, string userId)
    {
        var command = _mapper.Map<CreateAdvertisementCommand>((request, userId));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<AdvertisementResponse>(commandResult);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateAdvertisementRequest request, string userId, string id)
    {
        var command = _mapper.Map<UpdateAdvertisementCommand>((request, userId, id));
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<AdvertisementResponse>(commandResult);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string userId, string id)
    {
        var command = _mapper.Map<DeleteAdvertisementCommand>((userId, id));
        await _mediator.Send(command);
        
        return NoContent();
    }
}