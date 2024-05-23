using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Application.Skills.Commands.UpdateSkill;
using JobMaster.Contracts.Skills;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using Mapster;

namespace JobMaster.Api.Skills.Mapping;

public class SkillMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Skill, SkillResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.ForType<CreateSkillRequest, CreateSkillCommand>();

        config.ForType<(UpdateSkillRequest request, string id), UpdateSkillCommand>()
            .Map(dest => dest.Id, src => SkillId.Create(src.id))
            .Map(dest => dest, src => src.request);
    }
}