using Calisthenics.Database.Repositories.Interfaces;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Exercises.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    
    public async Task<List<Exercise>> GetAll(CancellationToken cancellationToken)
    {
        var exercisesEntities = await _exerciseRepository.GetAllAsync(cancellationToken);
        if (exercisesEntities.Count == 0)
        {
            return [];
        }

        return exercisesEntities.Select(x => x.ToDomain()).ToList();
    }

    public async Task AddAsync(Exercise exercise, CancellationToken cancellationToken)
    {
        var exerciseEntity = exercise.ToEntity();
        await _exerciseRepository.AddAsync(exerciseEntity);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
       await _exerciseRepository.DeleteAsync(id);
    }
}