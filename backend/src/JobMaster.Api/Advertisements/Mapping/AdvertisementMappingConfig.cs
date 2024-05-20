using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;
using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.Advertisements.Queries.GetAdvertisement;
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
            .Map(dest => dest.Skills, src => src.Skills.Select(x => new Guid(x)).ToList());

        config.ForType<(UpdateAdvertisementRequest request, string id), UpdateAdvertisementCommand>()
            .Map(dest => dest.Id, src => new Guid(src.id))
            .Map(dest => dest.Skills, src => src.request.Skills.Select(x => new Guid(x)).ToList())
            .Map(dest => dest, src => src.request);

        config.ForType<string, DeleteAdvertisementCommand>()
            .MapWith(src => new DeleteAdvertisementCommand(new Guid(src)));

        config.ForType<string, GetAdvertisementQuery>()
            .MapWith(src => new GetAdvertisementQuery(new Guid(src)));
    }
}