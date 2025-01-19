using Calisthenics.Database.Contexts;
using Calisthenics.Database.Repositories;
using Calisthenics.Database.Repositories.Interfaces;
using Calisthenics.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calisthenics.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCalisthenicsDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        
    }
    
    
    
}