using JobMaster.Domain.Common.Models.Interfaces;

namespace JobMaster.Domain.Skills.Events;

public record SkillDeletedEvent(
    Skill Skill)
    : IDomainEvent;