using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calisthenics.Database.Persistence.Configurations;

public class UserExerciseProgressConfiguration : IEntityTypeConfiguration<UserExerciseProgressEntity>
{
    public void Configure(EntityTypeBuilder<UserExerciseProgressEntity> builder)
    {
        // Table name
        builder.ToTable("UserExerciseProgress");

        // Primary Key
        builder.HasKey(ue => ue.Id);

        // Foreign Key to User
        builder.HasOne(ue => ue.UserEntity)
            .WithMany(u => u.UserExerciseProgress)
            .HasForeignKey(ue => ue.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // // Foreign Key to Exercise
        // builder.HasOne(ue => ue.ExerciseEntity)
        //     .WithMany(e => e.UserExerciseProgress)
        //     .HasForeignKey(ue => ue.ExerciseId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // Property configurations
        builder.Property(ue => ue.RepsCompleted)
            .IsRequired();

        builder.Property(ue => ue.SetsCompleted)
            .IsRequired();

        builder.Property(ue => ue.CompletionTime)
            .IsRequired(false); // Optional for timed exercises

        builder.Property(ue => ue.WeightLifted)
            .IsRequired(false); // Optional for weight-based exercises

        builder.Property(ue => ue.ProgressStatus)
            .HasMaxLength(50)
            .IsRequired(false); // Optional for tracking progression status

        builder.Property(ue => ue.LastCompletedDate)
            .IsRequired();

        // Ignoring TotalEffort as it is a computed property
        builder.Ignore(ue => ue.TotalEffort);
    }
}