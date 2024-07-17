using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.Exceptions;
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
        var advertisement = await _advertisementRepository.GetByIdAsync(request.UserId, request.Id) 
            ?? throw new AdvertisementNotFoundException(request.Id);

        advertisement.Update(
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

        await _advertisementRepository.UpdateAsync(advertisement);
        return advertisement;
    }
}