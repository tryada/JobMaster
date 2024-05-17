using JobMaster.Api.Common.Controllers;
using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Queries.ListAdvertisements;
using JobMaster.Contracts.Advertisements;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Api.Advertisements.Controllers;

public class AdvertisementsController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListAdvertisementsQuery();
        var queryResult = await _mediator.Send(query);
        
        var result = queryResult.Select(x => new AdvertisementResponse(
            x.Id.ToString(),
            x.Title,
            x.CompanyName,
            x.Description,
            x.Skills.Select(x => x.ToString()).ToArray(),
            x.Url,
            x.Applied,
            x.AppliedDate,
            x.Rejected
        )).ToList();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateAdvertisementRequest request)
    {
        var command = new CreateAdvertisementCommand(
            request.Title,
            request.CompanyName,
            request.Description,
            request.Skills.Select(x => new Guid(x)).ToArray(),
            request.Url,
            request.Applied,
            request.AppliedDate,
            request.Rejected
        );

        var commandResult = await _mediator.Send(command);

        var result = new AdvertisementResponse(
            commandResult.Id.ToString(),
            commandResult.Title,
            commandResult.CompanyName,
            commandResult.Description,
            commandResult.Skills.Select(x => x.ToString()).ToArray(),
            commandResult.Url,
            commandResult.Applied,
            commandResult.AppliedDate,
            commandResult.Rejected
        );

        return Ok(commandResult);
    }
}