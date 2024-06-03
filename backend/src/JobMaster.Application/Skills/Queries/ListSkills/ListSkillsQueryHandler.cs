using JobMaster.Application.Skills.Interfaces.Persistence;
using JobMaster.Domain.Skills;
using MediatR;

namespace JobMaster.Application.Skills.Queries.ListSkills;

public class ListSkillsQueryHandler : IRequestHandler<ListSkillsQuery, List<Skill>>
{
    private readonly ISkillRepository _skillsRepository;

    public ListSkillsQueryHandler(ISkillRepository skillsRepository)
    {
        _skillsRepository = skillsRepository;
    }

    public async Task<List<Skill>> Handle(ListSkillsQuery request, CancellationToken cancellationToken)
    {
        return await _skillsRepository.GetAllAsync(request.UserId);
    }
}