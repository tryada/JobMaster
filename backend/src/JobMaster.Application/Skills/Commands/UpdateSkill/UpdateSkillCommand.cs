using JobMaster.Application.Skills.Commands.Common.Interfaces;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Skills.Commands.UpdateSkill;

public record UpdateSkillCommand(
    UserId UserId,
    SkillId Id, 
    string Name) 
    : IRequest<Skill>, ISkillValidationFields;