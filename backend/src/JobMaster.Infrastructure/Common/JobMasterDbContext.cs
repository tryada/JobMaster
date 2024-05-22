using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Skills;
using Microsoft.EntityFrameworkCore;

namespace JobMaster.Infrastructure.Common;

public class JobMasterDbContext(DbContextOptions<JobMasterDbContext> options) : DbContext(options)
{
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobMasterDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}