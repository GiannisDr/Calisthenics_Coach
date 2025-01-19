using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Calisthenics.Database.DatabaseConfiguration;

/// <summary>
/// This logic will not bet used yet, is for reading the configurations dynamic from the database each time 
/// </summary>
public static class DatabaseConfigurationExtensions
{
    // public static IConfigurationBuilder AddDatabaseConfiguration(this IConfigurationBuilder builder,
    //     Action<DbContextOptionsBuilder> optionsAction)
    // {
    //     return builder.Add(new DatabaseConfigurationSource(optionsAction));
    // }
}