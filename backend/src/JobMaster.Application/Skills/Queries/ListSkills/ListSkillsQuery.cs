using JobMaster.Domain.Skills;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Skills.Queries.ListSkills;

public record ListSkillsQuery(
    UserId UserId
) : IRequest<List<Skill>>;