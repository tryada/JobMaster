using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;

public record DeleteAdvertisementCommand(
    UserId UserId,
    AdvertisementId Id) : IRequest;