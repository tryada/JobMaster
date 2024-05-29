using FluentValidation;
using FluentValidation.Results;
using JobMaster.Domain.Users;
using JobMaster.Domain.Users.Exceptions;

namespace JobMaster.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(User.FirstNameMaxLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(User.LastNameMaxLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(User.EmailMaxLength)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(User.PasswordMinLength);
    }

    protected override void RaiseValidationException(ValidationContext<RegisterCommand> context, ValidationResult result)
    {
        throw new UserValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
    }
}