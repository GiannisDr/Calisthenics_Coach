using Calisthenics.Domain.Common;
using Calisthenics.Domain.Enums;

namespace Calisthenics.Domain.Models;

public class Exercise : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}