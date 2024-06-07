using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Commands.DeleteSkill;
using JobMaster.Application.Skills.Commands.UpdateSkill;
using JobMaster.Application.Skills.Queries.ListSkills;
using JobMaster.Contracts.Skills;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using Mapster;

namespace JobMaster.Api.Skills.Mapping;

public class SkillMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Skill, SkillResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);

        config.ForType<(CreateSkillRequest request, string userId), CreateSkillCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest, src => src.request);

        config.ForType<(UpdateSkillRequest request, string userId, string id), UpdateSkillCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest.Id, src => SkillId.Create(src.id))
            .Map(dest => dest, src => src.request);

        config.ForType<string, ListSkillsQuery>()
            .MapWith(src => new ListSkillsQuery(UserId.Create(src)));

        config.ForType<(string userId, string id), DeleteSkillCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest.Id, src => SkillId.Create(src.id));
    }
}