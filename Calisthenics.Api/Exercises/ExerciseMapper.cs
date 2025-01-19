using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Exercises;

public static class ExerciseMapper
{
    public static ExerciseEntity ToEntity(this Exercise exercise)
    {

        return new ExerciseEntity
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Description = exercise.Description,
            DifficultyLevel = exercise.DifficultyLevel,
        };
    }
    
    public static Exercise ToDomain(this ExerciseEntity exerciseEntity)
    {
        return new Exercise
        {
            Id = exerciseEntity.Id,
            Name = exerciseEntity.Name,
            Description = exerciseEntity.Description,
            DifficultyLevel = exerciseEntity.DifficultyLevel
        };
    }
}