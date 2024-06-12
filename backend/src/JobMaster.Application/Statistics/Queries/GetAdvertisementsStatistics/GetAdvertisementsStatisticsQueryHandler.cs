using MediatR;

using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics.Result;

namespace JobMaster.Application.Statistics.Queries.GetAdvertisementsStatistics;

public class GetAdvertisementsStatisticsQueryHander(IAdvertisementRepository advertisementRepository)
    : IRequestHandler<GetAdvertisementsStatisticsQuery, AdvertisementsStatisticResult>
{
    private readonly IAdvertisementRepository _advertisementRepository = advertisementRepository;

    public async Task<AdvertisementsStatisticResult> Handle(GetAdvertisementsStatisticsQuery request, CancellationToken cancellationToken)
    {
        var advertisements = await _advertisementRepository.GetAllAsync(request.UserId);

        var result = new AdvertisementsStatisticResult(
            advertisements.Count,
            advertisements.Count(a => a.Applied),
            advertisements.Count(a => a.Rejected));

        return result;
    }
}