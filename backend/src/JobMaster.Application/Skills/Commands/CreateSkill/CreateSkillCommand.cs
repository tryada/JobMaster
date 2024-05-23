using JobMaster.Application.Skills.Commands.Common.Interfaces;
using JobMaster.Domain.Skills;
using MediatR;

namespace JobMaster.Application.Skills.Commands.CreateSkill;

public record CreateSkillCommand(
    string Name) 
    : IRequest<Skill>, ISkillValidationFields;