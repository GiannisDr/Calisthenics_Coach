using Calisthenics.Domain.Common;
using Calisthenics.Domain.Enums;

namespace Calisthenics.Database.Persistence.Entities;

public class ExerciseEntity : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DifficultyLevel DifficultyLevel { get; set; }
}