using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Calisthenics.Database.DatabaseConfiguration;

// public class DatabaseConfigurationSource : IConfigurationSource
// {
//     private readonly Action<DbContextOptionsBuilder> _optionsAction;
//
//     public DatabaseConfigurationSource(Action<DbContextOptionsBuilder> optionsAction)
//     {
//         _optionsAction = optionsAction;
//     }
//
//     public IConfigurationProvider Build(IConfigurationBuilder builder)
//     {
//         return new DatabaseConfigurationProvider(_optionsAction);
//     }
// }