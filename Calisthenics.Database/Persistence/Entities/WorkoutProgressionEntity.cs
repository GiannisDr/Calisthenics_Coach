using Calisthenics.Domain.Common;

namespace Calisthenics.Database.Persistence.Entities;

public class WorkoutProgressionEntity : BaseEntity
{
    
    // Foreign Key to User
    public int UserId { get; set; }
    public UserEntity UserEntity { get; set; }
    
    // Foreign Key to Workout
    public int WorkoutId { get; set; }
    public WorkoutEntity WorkoutEntity { get; set; }

    // Number of workouts completed at a certain difficulty level
    public int WorkoutsCompleted { get; set; }

    // For tracking time-based workouts, e.g., average time to complete the workout
    public TimeSpan? AverageCompletionTime { get; set; }
    
    // Criteria flag to check if the user has met the conditions to level up
    public bool LevelUpCriteriaMet { get; set; }

    // Date when this workout was completed
    public DateTime CompletionDate { get; set; }

    // The user's progress status for the workout
    public string ProgressStatus { get; set; }  // e.g., "Completed", "InProgress", "Skipped"
    
}