using Calisthenics.Database.Contexts;
using Calisthenics.Database.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Calisthenics.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCalisthenicsDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Register repositories
        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        
    }
    
    
    
}