using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;
using MediatR;

namespace JobMaster.Application.Skills.Commands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Skill>
{
    private readonly ISkillRepository _skillsRepository;

    public CreateSkillCommandHandler(ISkillRepository skillsRepository)
    {
        _skillsRepository = skillsRepository;
    }

    public async Task<Skill> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = Skill.Create(
            request.UserId,
            request.Name);
            
        await _skillsRepository.AddAsync(skill);
        return skill;
    }
}