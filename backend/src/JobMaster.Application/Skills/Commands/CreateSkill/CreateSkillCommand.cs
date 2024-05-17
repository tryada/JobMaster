using JobMaster.Domain.Skills;
using MediatR;

namespace JobMaster.Application.Skills.Commands.CreateSkill;

public record CreateSkillCommand(string Name) : IRequest<Skill>;