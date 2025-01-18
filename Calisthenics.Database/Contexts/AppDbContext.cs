using Calisthenics.Database.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calisthenics.Database.Contexts;

public class AppDbContext : DbContext
{
    internal const string ConnectionsStringKey = "Database";
    private readonly string _connectionString;
    
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<UserExerciseProgress> UserExerciseProgress { get; set; }
    public DbSet<WorkoutProgression> WorkoutProgression { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    internal AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
    
    
}