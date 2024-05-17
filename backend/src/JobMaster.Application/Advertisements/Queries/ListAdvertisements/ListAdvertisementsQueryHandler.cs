using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Domain.Advertisements;

using MediatR;

namespace JobMaster.Application.Advertisements.Queries.ListAdvertisements;

public class ListAdvertisementsQueryHandler : IRequestHandler<ListAdvertisementsQuery, List<Advertisement>>
{
    private readonly IAdvertisementRepository _advertisementRepository;

    public ListAdvertisementsQueryHandler(IAdvertisementRepository advertisementRepository)
    {
        _advertisementRepository = advertisementRepository;
    }

    public async Task<List<Advertisement>> Handle(ListAdvertisementsQuery request, CancellationToken cancellationToken)
    {
        return await _advertisementRepository.GetAllAsync();
    }
}