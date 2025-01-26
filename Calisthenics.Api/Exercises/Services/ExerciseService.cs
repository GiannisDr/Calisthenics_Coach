using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Calisthenics.Clients;
using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Database.Repositories.Interfaces;
using Calisthenics.Domain.Enums;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Exercises.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseClient _exerciseClient;

    public ExerciseService(
        IExerciseRepository exerciseRepository, 
        IExerciseClient exerciseClient)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseClient = exerciseClient;
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

    public async  Task<List<Exercise>> GetGeneratedExercises(CancellationToken cancellationToken)
    {
        // Build the full prompt
        var prompt = $"Generate a list of {DifficultyLevel.Pro} calisthenics exercises. " +
                     $"Focus on the following muscle groups: back. " +
                     "For each exercise, include the name, description, and difficulty level.";

       
        var apiResponse = await _exerciseClient.SendPromptAsync(prompt);
        
        // Get the text from the first choice
        var text = apiResponse.Choices[0].Text;

        // Split the text into individual exercises
        var exerciseBlocks = text.Split("\n\n---\n\n");

        var exercises = new List<Exercise>();

        foreach (var block in exerciseBlocks)
        {
            var lines = block.Split('\n');

            if (lines.Length >= 3)
            {
                // Extract name
                var match = Regex.Match(lines[0], @"\d+\. \*\*(.*?)\*\*");
                if (!match.Success)
                {
                    continue;
                }
                var name = match.Groups[1].Value;
                var exercise = new Exercise
                {
                    Name = name, 
                    Description = lines[1].Replace("- **Description**: ", "").Trim(), // Extract description
                    DifficultyLevel = DifficultyLevel.Pro
                };

                exercises.Add(exercise);
            }
        }
        return exercises;
    }

    public async Task<List<Exercise>> GetByDifficultyLevel(DifficultyLevel difficultyLevel, CancellationToken cancellationToken)
    {
        Expression<Func<ExerciseEntity, bool>> predicate = exercise => exercise.DifficultyLevel == difficultyLevel;
        var exercisesEntities = await _exerciseRepository.FindAsync(predicate);
        if (exercisesEntities.Count == 0)
        {
            return [];
        }

        return exercisesEntities.Select(x => x.ToDomain()).ToList();
    }
}

