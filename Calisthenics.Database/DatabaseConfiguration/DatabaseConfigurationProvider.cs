using Calisthenics.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Calisthenics.Database.DatabaseConfiguration;

// public class DatabaseConfigurationProvider : ConfigurationProvider
// {
//     private readonly Action<DbContextOptionsBuilder> _optionsAction;
//
//     public DatabaseConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
//     {
//         _optionsAction = optionsAction;
//     }
//
//     public override void Load()
//     {
//         var builder = new DbContextOptionsBuilder<AppDbContext>();
//         _optionsAction(builder);
//         using var context = new AppDbContext(builder.Options);
//        Data = context.ApplicationConfigurations.ToDictionary(x => x.Key, x => x.Value)!;
//     }
// }