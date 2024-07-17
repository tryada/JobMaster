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

    public async Task<Advertisement> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var advertisement = Advertisement.Create(
            request.UserId,
            request.Title,
            request.CompanyName,
            request.Description,
            request.Url,
            request.Applied,
            request.AppliedDate,
            request.Rejected,
            request.Replied,
            request.ReplyDate,
            request.Skills);

        await _advertisementRepository.AddAsync(advertisement);
        return advertisement;
    }
}