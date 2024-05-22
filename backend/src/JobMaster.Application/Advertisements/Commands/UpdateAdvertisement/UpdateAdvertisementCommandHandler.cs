using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;

public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, Advertisement>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public UpdateAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task<Advertisement> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var advertisement = await _advertisementRepository.GetByIdAsync(request.Id) 
            ?? throw new ArgumentException($"{nameof(Advertisement)}: {request.Id}");

        advertisement.Update(
            request.Title,
            request.CompanyName,
            request.Description,
            request.Url,
            request.Applied,
            request.AppliedDate,
            request.Rejected);

        advertisement.UpdateSkills(request.Skills);

        await _advertisementRepository.UpdateAsync(advertisement);
        return advertisement;
    }
}