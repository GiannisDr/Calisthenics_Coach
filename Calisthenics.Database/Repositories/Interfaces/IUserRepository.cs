using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Domain.Enums;
using Calisthenics.Domain.Interfaces;

namespace Calisthenics.Database.Repositories.Interfaces;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity?> GetUserAsync(int userId);
    Task<List<UserEntity>> GetAllUsersAsync();
    Task<bool> UpdateUserLevelAsync(int userId, ExperienceLevel experienceLevel);
}