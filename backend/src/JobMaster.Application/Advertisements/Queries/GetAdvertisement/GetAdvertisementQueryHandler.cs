using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.Exceptions;
using MediatR;

namespace JobMaster.Application.Advertisements.Queries.GetAdvertisement;

public class GetAdvertisementQueryHandler : IRequestHandler<GetAdvertisementQuery, Advertisement>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public GetAdvertisementQueryHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task<Advertisement> Handle(GetAdvertisementQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementRepository.GetByIdAsync(request.Id)
            ?? throw new AdvertisementNotFoundException(request.Id);
    }
}