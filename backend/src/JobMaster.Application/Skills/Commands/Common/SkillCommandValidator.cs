using FluentValidation;
using FluentValidation.Results;
using JobMaster.Application.Skills.Commands.Common.Interfaces;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.Exceptions;

public class SkillCommandValidator<TModel> : AbstractValidator<TModel>
    where TModel : ISkillValidationFields
{
    public SkillCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(Skill.NameMaxLength);
    }

    protected override void RaiseValidationException(ValidationContext<TModel> context, ValidationResult result)
    {
        throw new SkillValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
    }
}