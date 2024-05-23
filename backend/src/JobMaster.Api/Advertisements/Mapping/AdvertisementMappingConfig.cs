using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;
using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.Advertisements.Queries.GetAdvertisement;
using JobMaster.Contracts.Advertisements;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using Mapster;

namespace JobMaster.Api.Advertisements.Mapping;

public class AdvertisementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Advertisement, AdvertisementResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Skills, src => src.Skills.Select(x => x.ToString()).ToArray());

        config.ForType<CreateAdvertisementRequest, CreateAdvertisementCommand>()
            .Map(dest => dest.Skills, src => src.Skills.Select(SkillId.Create).ToList());

        config.ForType<(UpdateAdvertisementRequest request, string id), UpdateAdvertisementCommand>()
            .Map(dest => dest.Id, src => AdvertisementId.Create(src.id))
            .Map(dest => dest.Skills, src => src.request.Skills.Select(SkillId.Create).ToList())
            .Map(dest => dest, src => src.request);

        config.ForType<string, DeleteAdvertisementCommand>()
            .MapWith(src => new DeleteAdvertisementCommand(AdvertisementId.Create(src)));

        config.ForType<string, GetAdvertisementQuery>()
            .MapWith(src => new GetAdvertisementQuery(AdvertisementId.Create(src)));
    }
}