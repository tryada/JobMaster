using Microsoft.EntityFrameworkCore;
using FluentAssertions;

using JobMaster.Domain.Users;
using JobMaster.Infrastructure.Advertisements.Persistence;
using JobMaster.Infrastructure.Common;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Skills.ValueObjects;
using JobMaster.Application.Advertisements.Interfaces.Persistence;
using JobMaster.Infrastructure.UnitTests.Advertisements.Utils;

namespace JobMaster.Infrastructure.UnitTests.Advertisements;

public class AdvertisementRepositoryTests : IDisposable
{
    private readonly JobMasterDbContext _context;
    private readonly IAdvertisementRepository _repository;

    public AdvertisementRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<JobMasterDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        _context = new JobMasterDbContext(options, default);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        _repository = new AdvertisementRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public async Task AddAsync_AddToDatabase_IfAdvertisementIsValid()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateAdvertisement();

        // Act
        await _repository.AddAsync(advertisement);

        // Assert
        var result = await _context.Advertisements.SingleAsync();
        result.Should().BeEquivalentTo(advertisement);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnAdvertisement_IfAdvertisementExists()
    {
        // Arrange
        var userId = UserId.CreateUnique();
        var advertisement = AdvertisementUtils.CreateAdvertisement(userId);

        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(userId, advertisement.Id);

        // Assert
        result.Should().BeEquivalentTo(advertisement);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnNull_IfAdvertisementDoesNotExist()
    {
        // Arrange
        var userId = UserId.CreateUnique();
        var advertisement = AdvertisementUtils.CreateAdvertisement(userId);

        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(userId, AdvertisementId.CreateUnique());

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAllAsync_ReturnAdvertisements_IfAdvertisementsExist()
    {
        // Arrange
        var userId = UserId.CreateUnique();
        var advertisement1 = AdvertisementUtils.CreateAdvertisement(userId);
        var advertisement2 = AdvertisementUtils.CreateAdvertisement(userId);

        await _context.Advertisements.AddRangeAsync(advertisement1, advertisement2);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync(userId);

        // Assert
        result.Should().BeEquivalentTo(new[] { advertisement1, advertisement2 });
    }

    [Fact]
    public async Task GetAllAsync_ReturnEmptyList_IfAdvertisementsDoNotExist()
    {
        // Arrange
        var userId = UserId.CreateUnique();

        // Act
        var result = await _repository.GetAllAsync(userId);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task UpdateAsync_UpdateAdvertisementInDatabase_IfAdvertisementIsValid()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateAdvertisement();

        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();

        advertisement.Update("New Title", "New Company", "New Description", "New Url", true, null, true, [SkillId.CreateUnique()]);

        // Act
        await _repository.UpdateAsync(advertisement);

        // Assert
        var result = await _context.Advertisements.SingleAsync();
        result.Should().BeEquivalentTo(advertisement);
    }

    [Fact]
    public async Task DeleteAsync_RemoveAdvertisementFromDatabase_IfAdvertisementExists()
    {
        // Arrange
        var advertisement = AdvertisementUtils.CreateAdvertisement();

        await _context.Advertisements.AddAsync(advertisement);
        await _context.SaveChangesAsync();

        // Act
        await _repository.DeleteAsync(advertisement);

        // Assert
        var result = await _context.Advertisements.AnyAsync();
        result.Should().BeFalse();
    }
}