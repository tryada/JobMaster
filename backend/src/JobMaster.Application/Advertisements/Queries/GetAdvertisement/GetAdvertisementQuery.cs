using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.GetAdvertisement;

public record GetAdvertisementQuery(
    UserId UserId,
    AdvertisementId Id) 
    : IRequest<Advertisement>;