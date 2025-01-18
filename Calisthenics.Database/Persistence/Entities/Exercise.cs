using Calisthenics.Database.Persistence.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Foreign key to Workout
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    // Optional relationship for tracking progress
    public ICollection<UserExerciseProgress> ProgressRecords { get; set; } = new List<UserExerciseProgress>();
    public IEnumerable<UserExerciseProgress> UserExerciseProgress { get; set; }
}