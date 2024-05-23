using FluentValidation;
using FluentValidation.Results;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.Exceptions;

namespace JobMaster.Application.Advertisements.Commands.CreateAdvertisement;

public sealed class CreateAdvertisementCommandValidator : AbstractValidator<CreateAdvertisementCommand>
{
    public CreateAdvertisementCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Advertisement.TitleMaxLength);

        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(Advertisement.CompanyNameMaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(Advertisement.DescriptionMaxLength);

        RuleFor(x => x.Url)
            .NotEmpty()
            .MaximumLength(Advertisement.UrlMaxLength);
    }

    protected override void RaiseValidationException(ValidationContext<CreateAdvertisementCommand> context, ValidationResult result)
    {
        throw new AdvertisementValidationException(result.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage));
    }
}