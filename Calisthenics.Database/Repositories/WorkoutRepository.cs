using Calisthenics.Database.Contexts;
using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Database.Repositories.Interfaces;

namespace Calisthenics.Database.Repositories;

public class WorkoutRepository : Repository<WorkoutEntity> , IWorkoutRepository
{
    public WorkoutRepository(AppDbContext context) : base(context)
    {
    }
} 