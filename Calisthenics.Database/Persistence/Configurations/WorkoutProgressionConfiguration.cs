using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calisthenics.Database.Persistence.Configurations;

public class WorkoutProgressionConfiguration : IEntityTypeConfiguration<WorkoutProgression>
{
    public void Configure(EntityTypeBuilder<WorkoutProgression> builder)
    {
        // Table name
        builder.ToTable("WorkoutProgression");

        // Primary Key
        builder.HasKey(wp => wp.Id);

        // Foreign Key to User
        builder.HasOne(wp => wp.User)
            .WithMany(u => u.WorkoutProgression)
            .HasForeignKey(wp => wp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign Key to Workout
        builder.HasOne(wp => wp.Workout)
            .WithMany(w => w.WorkoutProgression)
            .HasForeignKey(wp => wp.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        // Property configurations
        builder.Property(wp => wp.WorkoutsCompleted)
            .IsRequired();

        builder.Property(wp => wp.AverageCompletionTime)
            .IsRequired(false); // Optional for time-based workouts

        builder.Property(wp => wp.LevelUpCriteriaMet)
            .IsRequired(); // Required to track if user has met level-up criteria

        builder.Property(wp => wp.CompletionDate)
            .IsRequired();

        builder.Property(wp => wp.ProgressStatus)
            .HasMaxLength(50)
            .IsRequired(false); // Optional for tracking progress of the workout (e.g., "Completed", "InProgress", "Skipped")
    }
}