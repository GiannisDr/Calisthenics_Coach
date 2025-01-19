using Calisthenics.Domain.Common;
using Calisthenics.Domain.Enums;

namespace Calisthenics.Domain.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; } 
    public WorkoutFrequency Frequency { get; set; }
}