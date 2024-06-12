using MediatR;

using JobMaster.Domain.Users;
using JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics.Result;

namespace JobMaster.Application.Advertisements.Queries.GetAdvertisementsStatistics;

public record GetAdvertisementsStatisticsQuery(
    UserId UserId)
    : IRequest<AdvertisementsStatisticResult>;