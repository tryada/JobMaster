using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using JobMaster.Domain.Advertisements;
using JobMaster.Domain.Advertisements.ValueObjects;
using JobMaster.Domain.Users;
using JobMaster.Infrastructure.Common.Persistence;

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

        builder.Property(advertisement => advertisement.UserId)
            .IsRequired()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(advertisement => advertisement.Title)
            .IsRequired()
            .HasMaxLength(Advertisement.TitleMaxLength);

        builder.Property(advertisement => advertisement.CompanyName)
            .IsRequired()
            .HasMaxLength(Advertisement.CompanyNameMaxLength);

        builder.Property(advertisement => advertisement.Description)
            .HasMaxLength(Advertisement.DescriptionMaxLength);

        builder.Property(advertisement => advertisement.Url)
            .IsRequired()
            .HasMaxLength(Advertisement.UrlMaxLength);

        builder.Property(advertisement => advertisement.Applied)
            .HasDefaultValue(false);

        builder.Property(advertisement => advertisement.AppliedDate)
            .IsRequired(false)
            .HasColumnType(ColumnTypeNames.Date);

        builder.Property(advertisement => advertisement.Rejected)
            .HasDefaultValue(false);

        builder.Property(advertisement => advertisement.Replied)
            .HasDefaultValue(false);

        builder.Property(advertisement => advertisement.RepliedDate)
            .IsRequired(false)
            .HasColumnType(ColumnTypeNames.Date);
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
                .HasColumnName("SkillId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Advertisement.Skills))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}