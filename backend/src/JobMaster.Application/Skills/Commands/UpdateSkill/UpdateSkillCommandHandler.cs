using JobMaster.Application.Skills.Commands.UpdateSkill;
using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.Exceptions;
using MediatR;

public class UpdateSkillCommmandHandler 
    : IRequestHandler<UpdateSkillCommand, Skill>
{
    private readonly ISkillRepository _skillRepository;

    public UpdateSkillCommmandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<Skill> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.UserId, request.Id)
            ?? throw new SkillNotFoundException(request.Id);

        skill.Update(
            request.Name);

        await _skillRepository.UpdateAsync(skill);
        return skill;
    }
}
