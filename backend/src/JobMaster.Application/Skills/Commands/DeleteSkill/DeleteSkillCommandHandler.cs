using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills.Exceptions;
using MediatR;

namespace JobMaster.Application.Skills.Commands.DeleteSkill;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand>
{
    private readonly ISkillRepository _skillRepository;

    public DeleteSkillCommandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.UserId, request.Id)
            ?? throw new SkillNotFoundException(request.Id);

        skill.Delete();

        await _skillRepository.DeleteAsync(skill);
    }
}