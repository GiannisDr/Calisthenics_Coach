using Calisthenics.Domain.Common;
using Calisthenics.Domain.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class UserEntity: BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; } // Weight in kilograms
    public WorkoutFrequency Frequency { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    public UserRole Role { get; set; } // Role as an enum
    // Navigation Properties
    public ICollection<UserExerciseProgressEntity> UserExerciseProgress { get; set; }
    public ICollection<WorkoutProgressionEntity> WorkoutProgression { get; set; }
}