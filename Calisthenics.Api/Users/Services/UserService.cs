using Calisthenics.Database.Repositories.Interfaces;
using Calisthenics.Domain.Models;

namespace Calisthenics.Api.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        var usersEntities = await _userRepository.GetAllUsersAsync();
        if (usersEntities.Count == 0)
        {
            return [];
        }

        return usersEntities.Select(x => x.ToDomain()).ToList();
    }
    
    
    // public async Task<User?> GetUserById(Guid userId)
    // {
    //     return await _userRepository.GetByIdAsync(userId);
    // }
    //
    // public async Task<User> RegisterUser(User user)
    // {
    //     user.CreatedAt = DateTime.UtcNow;
    //     await _userRepository.AddAsync(user);
    //     return user;
    // }
    //
    // public async Task UpdateUser(User user)
    // {
    //     await _userRepository.UpdateAsync(user);
    // }
   
}