using FluentAssertions;

using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement.Utils;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement;

public class CreateAdvertisementCommandValidatorTests
{
    private readonly CreateAdvertisementCommandValidator _validator;

    public CreateAdvertisementCommandValidatorTests()
    {
        _validator = new CreateAdvertisementCommandValidator();
    }

    [Fact]
    public void Validate_IsValid_IfCommandIsValid()
    {
        // Arrange
        var command = CreateAdvertisementCommandUtils.CreateValidCommand();

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(GetInvalidCommands))]
    public void Validate_IsInvalid_IfCommandIsInvalid(CreateAdvertisementCommand invalidCommand)
    {
        // Act
        var result = _validator.Validate(invalidCommand);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    public static IEnumerable<object[]> GetInvalidCommands()
    {
        yield return new object[] { CreateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyTitle() };
        yield return new object[] { CreateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyCompanyName() };
        yield return new object[] { CreateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyUrl() };
    }
}