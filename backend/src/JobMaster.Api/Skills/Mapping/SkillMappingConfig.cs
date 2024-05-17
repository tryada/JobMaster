using JobMaster.Application.Skills.Commands.CreateSkill;
using JobMaster.Contracts.Skills;
using JobMaster.Domain.Skills;
using Mapster;

namespace JobMaster.Api.Skills.Mapping;

public class SkillMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Skill, SkillResponse>()
            .Map(dest => dest.Id, src => src.Id.ToString());

        config.ForType<CreateSkillRequest, CreateSkillCommand>();
    }
}