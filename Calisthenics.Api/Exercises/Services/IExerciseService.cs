using Calisthenics.Domain.Enums;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Exercises.Services;

public interface IExerciseService
{
    Task<List<Exercise>> GetAll(CancellationToken cancellationToken);
    Task AddAsync(Exercise request, CancellationToken cancellationToken);
    Task DeleteAsync(int id,CancellationToken cancellationToken);
    Task<List<Exercise>> GetGeneratedExercises(CancellationToken cancellationToken);
    Task<List<Exercise>> GetByDifficultyLevel(DifficultyLevel difficultyLevel, CancellationToken cancellationToken);
}