using FluentValidation;
using FluentValidation.Results;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.Exceptions;

namespace JobMaster.Application.Skills.Commands.CreateSkill;

public sealed class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(Skill.NameMaxLength);
    }

    protected override void RaiseValidationException(ValidationContext<CreateSkillCommand> context, ValidationResult result)
    {
        throw new SkillValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
    }
}