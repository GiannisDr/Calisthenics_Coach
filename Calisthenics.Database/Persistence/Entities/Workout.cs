using Calisthenics.Database.Persistence.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    // Foreign key to User
    public int UserId { get; set; }
    public User User { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    // New relationship
    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    public IEnumerable<WorkoutProgression> WorkoutProgression { get; set; }
}