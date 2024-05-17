using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.CreateAdvertisement;

public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, Advertisement>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public CreateAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public Task<Advertisement> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var advertisement = Advertisement.Create(
            request.Title,
            request.Description,
            request.CompanyName,
            request.Skills,
            request.Url,
            request.Applied,
            request.AppliedDate,
            request.Rejected
        );

        _advertisementRepository.AddAsync(advertisement);
        return Task.FromResult(advertisement);
    }
}