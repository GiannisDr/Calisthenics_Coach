using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calisthenics.Database.Persistence.Configurations;

public class ApplicationConfigurationsConfiguration : IEntityTypeConfiguration<ApplicationConfigurationEntity>
{
    public void Configure(EntityTypeBuilder<ApplicationConfigurationEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Key).IsRequired().HasMaxLength(255);
        builder.Property(e => e.Value).IsRequired();
    }
}