using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calisthenics.Database.Persistence.Configurations;

public class WorkoutConfiguration
{
    public void Configure(EntityTypeBuilder<WorkoutEntity> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Title).IsRequired().HasMaxLength(100);
        builder.Property(w => w.Description).HasMaxLength(500);
        builder.Property(w => w.DifficultyLevel).HasConversion<int>(); // Difficulty level for workouts

        builder.HasOne(w => w.UserEntity)
            .WithMany()
            .HasForeignKey(w => w.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}