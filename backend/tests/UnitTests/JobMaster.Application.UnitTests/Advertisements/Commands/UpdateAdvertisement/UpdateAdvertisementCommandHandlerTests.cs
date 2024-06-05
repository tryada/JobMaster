using FluentAssertions;
using Moq;

using JobMaster.Application.Advertisements.Commands.UpdateAdvertisement;
using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.UnitTests.Advertisements.Utils;
using JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement.Utils;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.Exceptions;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.UpdateAdvertisement;

public class UpdateAdvertisementCommandHandlerTests
{
    private readonly Mock<IAdvertisementRepository> _advertisementRepositoryMock;
    private readonly UpdateAdvertisementCommandHandler _handler;

    public UpdateAdvertisementCommandHandlerTests()
    {
        _advertisementRepositoryMock = new Mock<IAdvertisementRepository>();
        _handler = new UpdateAdvertisementCommandHandler(_advertisementRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_UpdateAndReturnAdvertisement_IfCommandIsValid()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateDefault();

        _advertisementRepositoryMock
            .Setup(x => x.GetByIdAsync(advertisement.UserId, advertisement.Id))
            .ReturnsAsync(advertisement);

        var command = UpdateAdvertisementCommandUtils.CreateCommand(
            advertisement,
            title: "New Title",
            companyName: "New CompanyName",
            description: "New Description",
            skills: [SkillId.CreateUnique()],
            url: "New Url",
            applied: true,
            appliedDate: DateTime.UtcNow,
            rejected: true
        );

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _advertisementRepositoryMock.Verify(x => x.UpdateAsync(result), Times.Once);
        UpdateAdvertisementCommandUtils.Assert(command, result);
    }

    [Fact]
    public async Task Handle_ThrowNotFoundException_IfAdvertisementNotFound()
    {
        // Arrange
        _advertisementRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<UserId>(), It.IsAny<AdvertisementId>()))
            .ReturnsAsync((Advertisement?)null);

        var command = UpdateAdvertisementCommandUtils.CreateValidCommand();

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<AdvertisementNotFoundException>();
        _advertisementRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Advertisement>()), Times.Never);
    }
}