using Microsoft.EntityFrameworkCore.Design;

namespace Calisthenics.Database.Contexts;

public class DatabaseContetDesignFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return new AppDbContext("Host=localhost;Port=5432;Database=calisthenics_coach;Username=coach_user;Password=your_secure_password");
    }
}