using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Users.Services;

public interface IUserService
{
     Task<List<User>> GetAllUsers(CancellationToken cancellationToken);
    // Task<User> RegisterUser(User user);
    // Task UpdateUser(User user);
}