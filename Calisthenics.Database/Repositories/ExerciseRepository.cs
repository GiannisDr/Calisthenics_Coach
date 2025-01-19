using Calisthenics.Database.Contexts;
using Calisthenics.Database.Persistence.Entities;
using Calisthenics.Database.Repositories.Interfaces;

namespace Calisthenics.Database.Repositories;

public class ExerciseRepository: Repository<ExerciseEntity> , IExerciseRepository
{
    public ExerciseRepository(AppDbContext context) : base(context)
    {
    }
} 