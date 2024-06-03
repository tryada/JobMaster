using JobMaster.Application.Skills.Commands.Common.Interfaces;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Skills.Commands.CreateSkill;

public record CreateSkillCommand(
    UserId UserId,
    string Name) 
    : IRequest<Skill>, ISkillValidationFields;