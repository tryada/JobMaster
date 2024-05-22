using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.GetAdvertisement;

public record GetAdvertisementQuery(
    AdvertisementId Id) : IRequest<Advertisement>;