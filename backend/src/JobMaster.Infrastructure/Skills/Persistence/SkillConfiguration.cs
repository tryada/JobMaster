using JobMaster.Domain.Skills;
using JobMaster.Domain.Skills.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Infrastructure.Skills.Persistence;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => (SkillId)value);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}