using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Database.Persistence.Enums;

namespace Calisthenics.Database.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(int userId);
    Task<bool> UpdateUserLevelAsync(int userId, ExperienceLevel experienceLevel);
}