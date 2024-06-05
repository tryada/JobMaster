using FluentAssertions;
using Moq;

using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.Advertisements.Queries.GetAdvertisement;
using JobMaster.Application.UnitTests.Advertisements.Utils;
using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Users;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Advertisements.Exceptions;

namespace JobMaster.Application.UnitTests.Advertisements.Queries.GetAdvertisement;

public class GetAdvertisementQueryHandlerTests
{
    private readonly Mock<IAdvertisementRepository> _advertisementRepositoryMock;
    private readonly GetAdvertisementQueryHandler _handler;

    public GetAdvertisementQueryHandlerTests()
    {
        _advertisementRepositoryMock = new Mock<IAdvertisementRepository>();
        _handler = new GetAdvertisementQueryHandler(_advertisementRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnAdvertisement_IfAdvertisementExist()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateDefault();
        _advertisementRepositoryMock
            .Setup(x => x.GetByIdAsync(advertisement.UserId, advertisement.Id))
            .ReturnsAsync(advertisement);

        var query = new GetAdvertisementQuery(advertisement.UserId, advertisement.Id);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().Be(advertisement);
        _advertisementRepositoryMock.Verify(x => x.GetByIdAsync(query.UserId, query.Id), Times.Once);
    }

    [Fact]
    public async Task Handle_ThrowNotFoundException_IfAdvertisementDoesNotExist()
    {
        // Arrange
        var userId = UserId.CreateUnique();
        var advertisementId = AdvertisementId.CreateUnique();

        _advertisementRepositoryMock
            .Setup(x => x.GetByIdAsync(userId, advertisementId))
            .ReturnsAsync((Advertisement?)null);

        var query = new GetAdvertisementQuery(
            userId,
            advertisementId);

        // Act
        var act = async () => await _handler.Handle(query, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<AdvertisementNotFoundException>();
        _advertisementRepositoryMock.Verify(x => x.GetByIdAsync(query.UserId, query.Id), Times.Once);
    }
}