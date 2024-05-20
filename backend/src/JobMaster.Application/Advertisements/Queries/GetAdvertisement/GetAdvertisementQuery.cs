using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.GetAdvertisement;

public record GetAdvertisementQuery(
    Guid Id) : IRequest<Advertisement>;