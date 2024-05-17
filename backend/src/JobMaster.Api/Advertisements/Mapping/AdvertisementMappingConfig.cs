using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Contracts.Advertisements;
using JobMaster.Domain.Advertisements;
using Mapster;

namespace JobMaster.Api.Advertisements.Mapping;

public class AdvertisementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Advertisement, AdvertisementResponse>()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.Skills, src => src.Skills.Select(x => x.ToString()).ToArray());

        config.ForType<CreateAdvertisementRequest, CreateAdvertisementCommand>()
            .Map(dest => dest.Skills, src => src.Skills.Select(x => new Guid(x)).ToArray());
    }
}