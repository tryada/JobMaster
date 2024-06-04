using FluentAssertions;

using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement.Utils;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement;

public class UpdateAdvertisementCommandValidatorTests
{
    private UpdateAdvertisementCommandValidator _validator;

    public UpdateAdvertisementCommandValidatorTests()
    {
        _validator = new UpdateAdvertisementCommandValidator();
    }

    [Fact]
    public void Validate_IsValid_IfCommandIsValid()
    {
        // Arrange
        var command = UpdateAdvertisementCommandUtils.CreateValidCommand();

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(GetInvalidCommands))]
    public void Validate_IsInvalid_IfCommandIsInvalid(UpdateAdvertisementCommand invalidCommand)
    {
        // Act
        var result = _validator.Validate(invalidCommand);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    public static IEnumerable<object[]> GetInvalidCommands()
    {
        yield return new object[] { UpdateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyTitle() };
        yield return new object[] { UpdateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyCompanyName() };
        yield return new object[] { UpdateAdvertisementCommandUtils.CreateInvalidCommandWithEmptyUrl() };
    }
}