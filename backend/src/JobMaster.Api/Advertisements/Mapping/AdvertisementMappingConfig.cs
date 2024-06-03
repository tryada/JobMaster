using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;
using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.Advertisements.Queries.GetAdvertisement;
using JobMaster.Application.Advertisements.Queries.ListAdvertisements;
using JobMaster.Contracts.Advertisements;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using Mapster;

namespace JobMaster.Api.Advertisements.Mapping;

public class AdvertisementMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Advertisement, AdvertisementResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Skills, src => src.Skills.Select(x => x.ToString()).ToArray());

        config.ForType<(CreateAdvertisementRequest request, string userId), CreateAdvertisementCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest.Skills, src => src.request.Skills.Select(SkillId.Create).ToList())
            .Map(dest => dest, src => src.request);

        config.ForType<(UpdateAdvertisementRequest request, string userId, string id), UpdateAdvertisementCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest.Id, src => AdvertisementId.Create(src.id))
            .Map(dest => dest.Skills, src => src.request.Skills.Select(SkillId.Create).ToList())
            .Map(dest => dest, src => src.request);

        config.ForType<(string userId, string id), DeleteAdvertisementCommand>()
            .Map(src => src.UserId, dest => UserId.Create(dest.userId))
            .Map(src => src.Id, dest => AdvertisementId.Create(dest.id));

        config.ForType<(string userId, string id), GetAdvertisementQuery>()
            .Map(src => src.UserId, dest => UserId.Create(dest.userId))
            .Map(src => src.Id, dest => AdvertisementId.Create(dest.id));

        config.ForType<string, ListAdvertisementsQuery>()
            .MapWith(src => new ListAdvertisementsQuery(UserId.Create(src)));
    }
}