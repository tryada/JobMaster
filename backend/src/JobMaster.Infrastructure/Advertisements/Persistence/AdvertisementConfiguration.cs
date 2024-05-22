using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMaster.Infrastructure.Advertisements.Persistence;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        ConfigureAdvertisementTable(builder);
        ConfigureAdvertisementSkillIdsTable(builder);
    }

    private static void ConfigureAdvertisementTable(EntityTypeBuilder<Advertisement> builder)
    {
        builder.ToTable("Advertisements");
        builder.HasKey(advertisement => advertisement.Id);
        builder.Property(advertisement => advertisement.Id)
         .ValueGeneratedNever()
         .HasConversion(id => id.Value, value => (AdvertisementId)value);

        builder.Property(advertisement => advertisement.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(advertisement => advertisement.CompanyName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(advertisement => advertisement.Description)
            .HasMaxLength(1000);

        builder.Property(advertisement => advertisement.Url)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(advertisement => advertisement.Applied)
            .HasDefaultValue(false);

        builder.Property(advertisement => advertisement.AppliedDate)
            .IsRequired(false);

        builder.Property(advertisement => advertisement.Rejected)
            .HasDefaultValue(false);
    }

    private void ConfigureAdvertisementSkillIdsTable(EntityTypeBuilder<Advertisement> builder)
    {
        builder.OwnsMany(
            advertisement => advertisement.Skills, 
            builder =>
        {
            builder.ToTable("AdvertisementSkills");
            builder.HasKey("Id");

            builder.WithOwner().HasForeignKey("AdvertisementId");

            builder.Property(d => d.Value)
                .HasColumnName("AdvertisementSkillId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Advertisement.Skills))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}