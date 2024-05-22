using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements.Errors.Exceptions;
using MediatR;

namespace JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;

public class DeleteAdvertisementCommandHandler : IRequestHandler<DeleteAdvertisementCommand>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public DeleteAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var advertisement = await _advertisementRepository.GetByIdAsync(request.Id) 
            ?? throw new AdvertisementNotFoundException(request.Id);

        await _advertisementRepository.DeleteAsync(advertisement);
    }
}