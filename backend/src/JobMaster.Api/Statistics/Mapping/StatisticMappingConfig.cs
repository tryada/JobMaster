using Mapster;

using JobMaster.Domain.Users;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics.Result;
using JobMaster.Contracts.Advertisements;

namespace JobMaster.Api.Statistics.Mapping;

public class StatisticsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<AdvertisementsStatisticResult, AdvertisementsStatisticsResponse>()
            .Map(dest => dest.Count, src => src.Count)
            .Map(dest => dest.AppliedCount, src => src.AppliedCount)
            .Map(dest => dest.RejectedCount, src => src.RejectedCount);

        config.ForType<string, GetAdvertisementsStatisticsQuery>()
            .MapWith(src => new GetAdvertisementsStatisticsQuery(UserId.Create(src)));
    }
}