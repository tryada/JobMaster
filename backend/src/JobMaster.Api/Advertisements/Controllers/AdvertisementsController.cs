using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Queries.ListAdvertisements;
using JobMaster.Contracts.Advertisements;
using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Advertisements.Controllers;

public class AdvertisementsController(IMediator mediator, IMapper mapper) : BaseController
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListAdvertisementsQuery();
        var queryResult = await _mediator.Send(query);
        
        var result = _mapper.Map<IEnumerable<AdvertisementResponse>>(queryResult);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAdvertisementRequest request)
    {
        var command = _mapper.Map<CreateAdvertisementCommand>(request);
        var commandResult = await _mediator.Send(command);

        var result = _mapper.Map<AdvertisementResponse>(commandResult);
        return Ok(result);
    }
}