using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using JobMaster.Api.Common.Controllers;
using JobMaster.Contracts.Advertisements;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics;

namespace JobMaster.Api.Statistics.Controller;

public class StatisticsController(IMediator mediator, IMapper mapper) 
    : BaseUserController(mediator, mapper)
{
    [HttpGet("advertisements")]
    public async Task<IActionResult> GetStatistics()
    {
        var query = _mapper.Map<GetAdvertisementsStatisticsQuery>(UserId);
        var queryResult = await _mediator.Send(query);

        var result = _mapper.Map<AdvertisementsStatisticsResponse>(queryResult);
        return Ok(result);
    }
}