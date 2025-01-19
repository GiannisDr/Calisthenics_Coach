namespace Calisthenics.Clients;

public interface IExerciseClient
{
    Task<ExerciseClientResponse> SendPromptAsync(string prompt);
}