using Calisthenics.Domain.Common;
using Calisthenics.Domain.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class WorkoutEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    // Foreign key to User
    public int UserId { get; set; }
    public UserEntity UserEntity { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    // New relationship
    public ICollection<ExerciseEntity> Exercises { get; set; } = new List<ExerciseEntity>();
    public IEnumerable<WorkoutProgressionEntity> WorkoutProgression { get; set; }
}