namespace Calisthenics.Api.Exercises;

public class AddExerciseRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Difficulty { get; set; }
}