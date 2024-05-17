using MediatR;

namespace JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;

public record DeleteAdvertisementCommand(
    Guid Id) : IRequest;