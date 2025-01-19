using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Calisthenics.Database.Contexts;

public class AppDbContext : DbContext
{
    internal const string ConnectionsStringKey = "Database";
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;

    public DbSet<ApplicationConfigurationEntity> ApplicationConfigurations { get; set; } = default!;
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ExerciseEntity> Exercises { get; set; }
    public DbSet<WorkoutEntity> Workouts { get; set; }
    public DbSet<UserExerciseProgressEntity> UserExerciseProgress { get; set; }
    public DbSet<WorkoutProgressionEntity> WorkoutProgression { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    

    internal AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    // public AppDbContext(IConfiguration configuration, ILoggerFactory loggerFactory)
    // {
    //     var connectionString = configuration.GetConnectionString(ConnectionsStringKey);
    //     ArgumentException.ThrowIfNullOrEmpty(connectionString);
    //     _connectionString = connectionString;
    // }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ensure connection string is loaded
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
    
    
}