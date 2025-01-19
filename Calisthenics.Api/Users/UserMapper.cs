using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Users;

public static class UserMapper
{
    // ToEntity: Maps from the API DTO (UserDto) to the entity model (UserEntity) for database operations
    public static UserEntity ToEntity(this User user)
    {

        return new UserEntity
        {
            Id = user.Id,
            Username = user.Username,
            Age = user.Age,
            Weight = user.Weight,
            ExperienceLevel = user.ExperienceLevel,
            Frequency = user.Frequency,
            // Email = null,
            // PasswordHash = null,
            // CreatedAt = default,
            //UserExerciseProgress = null,
            //WorkoutProgression = null,
        };
    }

    // ToDomain: Maps from the entity model (UserEntity) to the domain model (User)
    public static User ToDomain(this UserEntity userEntity)
    {
        return new User
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            Age = userEntity.Age,
            Weight = userEntity.Weight,
            ExperienceLevel = userEntity.ExperienceLevel,
            Frequency = userEntity.Frequency,
            // Other properties...
        };
    }
}