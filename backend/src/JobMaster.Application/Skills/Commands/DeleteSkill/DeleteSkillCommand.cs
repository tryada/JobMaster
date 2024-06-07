using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;
using MediatR;

namespace JobMaster.Application.Skills.Commands.DeleteSkill;

public record DeleteSkillCommand(
    UserId UserId,
    SkillId Id) : IRequest;