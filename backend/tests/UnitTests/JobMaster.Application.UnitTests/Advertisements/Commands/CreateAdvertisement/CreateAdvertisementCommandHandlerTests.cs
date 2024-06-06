using Moq;

using JobMaster.Application.Advertisements.Commands.CreateAdvertisement;
using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement.Utils;

namespace JobMaster.Application.UnitTests.Advertisements.Commands.CreateAdvertisement;

public class CreateAdvertisementCommandHandlerTests
{
    private readonly Mock<IAdvertisementRepository> _mockAdvertisementRepository;
    private readonly CreateAdvertisementCommandHandler _handler;

    public CreateAdvertisementCommandHandlerTests()
    {
        _mockAdvertisementRepository = new Mock<IAdvertisementRepository>();
        _handler = new CreateAdvertisementCommandHandler(_mockAdvertisementRepository.Object);
    }

    [Fact]
    public async Task Handle_ReturnCreatedAdvertisement_IfCommandIsValid()
    {
        // Arrange
        var command = CreateAdvertisementCommandUtils.CreateValidCommand();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mockAdvertisementRepository.Verify(x => x.AddAsync(result), Times.Once);
        CreateAdvertisementCommandUtils.Assert(command, result);
    }
}