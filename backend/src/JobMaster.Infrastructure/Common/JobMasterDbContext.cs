using Microsoft.EntityFrameworkCore;

using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills;
using JobMaster.Domain.Users;
using JobMaster.Infrastructure.Common.Persistence.Interceptors;
using JobMaster.Domain.Common.Models.Interfaces;

namespace JobMaster.Infrastructure.Common;

public class JobMasterDbContext(
    DbContextOptions<JobMasterDbContext> options,
    PublishDomainEventsInterceptor publishDomainEventsInterceptor) : DbContext(options)
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(JobMasterDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}