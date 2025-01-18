using Calisthenics.Database.Contexts;
using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Database.Persistence.Enums;
using Calisthenics.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calisthenics.Database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Retrieve a user by ID with their exercise progress and workouts
    public async Task<User?> GetUserAsync(int userId)
    {
        return await _context.Users
            .Include(u => u.UserExerciseProgress)
            .Include(u => u.WorkoutProgression)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    // Update the user's level based on their exercise progress
    public async Task<bool> UpdateUserLevelAsync(int userId, ExperienceLevel experienceLevel)
    {
        var user = await GetUserAsync(userId);

        if (user is null)
        {
            return false;
        } 
            
        user.ExperienceLevel = experienceLevel; // Move user to Intermediate level
        await _context.SaveChangesAsync();
        return true;
    }
}