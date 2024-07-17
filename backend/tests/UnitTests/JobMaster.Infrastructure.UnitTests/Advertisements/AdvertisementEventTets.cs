using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using MediatR;
using Moq;

using JobMaster.Domain.Advertisements.Events;
using JobMaster.Domain.Common.Models.Interfaces;
using JobMaster.Infrastructure.Common;
using JobMaster.Infrastructure.Common.Persistence.Interceptors;
using JobMaster.Infrastructure.UnitTests.Advertisements.Utils;

namespace JobMaster.Infrastructure.UnitTests.Advertisements;

public class AdvertisementEventTests : IDisposable
{
    private readonly JobMasterDbContext _context;
    private readonly Mock<IMediator> _mediator;

    public AdvertisementEventTests()
    {
        var options = new DbContextOptionsBuilder<JobMasterDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _mediator = new Mock<IMediator>();
        _context = new JobMasterDbContext(options, new PublishDomainEventsInterceptor(_mediator.Object));
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public async Task AddAsync_PublishAdvertisementCreatedEvent_IfAdvertisementIsValid()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateAdvertisement();
        var domainEvents = advertisement.DomainEvents.ToList();

        // Act
        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();

        // Assert
        domainEvents.Should().ContainSingle(x => x is AdvertisementCreatedEvent);
        _mediator.Verify(x => x.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_PublishAdvertisementUpdatedEvent_IfAdvertisementIsValid()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateAdvertisement();
        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();
        _mediator.Invocations.Clear();
        advertisement.Update("New Title", "New Company", "New Description", "New Url", true, DateTime.Now, true, false, null, []);
        var domainEvents = advertisement.DomainEvents.ToList();

        // Act
        _context.Advertisements.Update(advertisement);
        await _context.SaveChangesAsync();

        // Assert
        domainEvents.Should().ContainSingle(x => x is AdvertisementUpdatedEvent);
        _mediator.Verify(x => x.Publish(It.IsAny<IDomainEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}