using FluentAssertions;
using Moq;

using JobMaster.Application.Advertisements.Commands.DeleteAdvertisement;
using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.UnitTests.Advertisements.Commands.Shared.Utils;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.Exceptions;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Users;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.DeleteAdvertisement;

public class DeleteAdvertisementCommandHandlerTests
{
    private readonly Mock<IAdvertisementRepository> _advertisementRepository;
    private readonly DeleteAdvertisementCommandHandler _handler;

    public DeleteAdvertisementCommandHandlerTests()
    {
        _advertisementRepository = new Mock<IAdvertisementRepository>();
        _handler = new DeleteAdvertisementCommandHandler(_advertisementRepository.Object);
    }

    [Fact]
    public async Task Handle_DeleteAdvertisement_IfAdvertisementExists()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateDefault();

        _advertisementRepository
            .Setup(x => x.GetByIdAsync(advertisement.UserId, advertisement.Id))
            .ReturnsAsync(advertisement);

        var command = new DeleteAdvertisementCommand(advertisement.UserId, advertisement.Id);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _advertisementRepository.Verify(x => x.DeleteAsync(advertisement), Times.Once);
    }

    [Fact]
    public async Task Handle_ThrowNotFoundException_IfAdvertisementDoesNotExist()
    {
        // Arrange
        _advertisementRepository
            .Setup(x => x.GetByIdAsync(It.IsAny<UserId>(), It.IsAny<AdvertisementId>()))
            .ReturnsAsync((Advertisement?)null);

        var command = new DeleteAdvertisementCommand(UserId.CreateUnique(), AdvertisementId.CreateUnique());

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<AdvertisementNotFoundException>();
        _advertisementRepository.Verify(x => x.DeleteAsync(It.IsAny<Advertisement>()), Times.Never);
    }
}