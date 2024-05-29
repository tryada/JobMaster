using FluentValidation;
using FluentValidation.Results;
using JobMaster.Domain.Users;
using JobMaster.Domain.Users.Exceptions;

namespace JobMaster.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(User.EmailMaxLength)
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(User.PasswordMinLength);
    }

    protected override void RaiseValidationException(ValidationContext<LoginQuery> context, ValidationResult result)
    {
        throw new UserValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
    }
}