using JobMaster.Domain.Advertisements.ValueObjects;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;

public record DeleteAdvertisementCommand(
    AdvertisementId Id) : IRequest;