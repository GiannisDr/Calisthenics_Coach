using Calisthenics.Api.Exercises.Services;

namespace Calisthenics.Api.Exercises.Extensions;

public static class ExercisesInstallationExtensions
{
    public static void AddExerciseFeature(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        
    }
}