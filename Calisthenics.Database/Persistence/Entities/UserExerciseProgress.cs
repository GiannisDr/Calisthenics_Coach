namespace Calisthenics.Database.Persistence.Entities;

public class UserExerciseProgress
{
    public int Id { get; set; }
    
    // Foreign Key to User
    public int UserId { get; set; }
    public User User { get; set; }
    
    // Foreign Key to Exercise
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    // Reps and Sets completed by the user
    public int RepsCompleted { get; set; }
    public int SetsCompleted { get; set; }
    
    // For time-based exercises, e.g., planks
    public TimeSpan? CompletionTime { get; set; }  // Optional for exercises that are timed
    
    // For weight-based exercises, e.g., squats, deadlifts
    public double? WeightLifted { get; set; }  // Optional for weight-based exercises
    
    // The current progress status (optional, could be used for monitoring progression)
    public string ProgressStatus { get; set; }  // e.g., "Progressing", "Stagnating", "Regressing"
    
    // Date when this exercise was last completed
    public DateTime LastCompletedDate { get; set; }
    
    // This is used to track the total volume or total effort per exercise to gauge progression
    public double TotalEffort => RepsCompleted * SetsCompleted * (WeightLifted ?? 0);  // For weighted exercises

}