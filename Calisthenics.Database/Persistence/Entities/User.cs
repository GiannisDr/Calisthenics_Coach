using Calisthenics.Database.Persistence.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public int Age { get; set; }
    public double Weight { get; set; } // Weight in kilograms
    public WorkoutFrequency Frequency { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    // Navigation Properties
    public ICollection<UserExerciseProgress> UserExerciseProgress { get; set; }
    public ICollection<WorkoutProgression> WorkoutProgression { get; set; }
}