using FluentAssertions;
using Moq;

using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.Advertisements.Queries.ListAdvertisements;
using JobMaster.Domain.Users;
using JobMaster.Application.UnitTests.Advertisements.Utils;
using JobMaster.Domain.Advertisements;

namespace JobMaster.Application.UnitTests.Advertisements.Queries.ListAdvertisement;

public class ListAdvertisementQueryHandlerTests
{
    private readonly Mock<IAdvertisementRepository> _mockAdvertisementRepository;
    private readonly ListAdvertisementsQueryHandler _handler;

    public ListAdvertisementQueryHandlerTests()
    {
        _mockAdvertisementRepository = new Mock<IAdvertisementRepository>();
        _handler = new ListAdvertisementsQueryHandler(_mockAdvertisementRepository.Object);
    }

    [Fact]
    public async Task Handle_ReturnAdvertisements_IfAdvertisementsExists()
    {
        // Arrange
        var userId = UserId.CreateUnique();

        var advertisements = new List<Advertisement>
        {
            AdvertisementUtils.CreateWithUserId(userId),
            AdvertisementUtils.CreateWithUserId(userId),
            AdvertisementUtils.CreateWithUserId(userId)
        };

        _mockAdvertisementRepository
            .Setup(x => x.GetAllAsync(userId))
            .ReturnsAsync(advertisements);

        var query = new ListAdvertisementsQuery(
            userId);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(advertisements);
        _mockAdvertisementRepository.Verify(x => x.GetAllAsync(query.UserId), Times.Once);
    }

    [Fact]
    public async Task Handle_ReturnEmptyList_IfAdvertisementsDoesNotExist()
    {
        // Arrange
        var userId = UserId.CreateUnique();

        _mockAdvertisementRepository
            .Setup(x => x.GetAllAsync(userId))
            .ReturnsAsync([]);

        var query = new ListAdvertisementsQuery(
            userId);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeEmpty();
        _mockAdvertisementRepository.Verify(x => x.GetAllAsync(query.UserId), Times.Once);
    }
}