using JobMaster.Domain.Skills;
using MediatR;

namespace JobMaster.Application.Skills.Queries.ListSkills;

public record ListSkillsQuery : IRequest<List<Skill>>;