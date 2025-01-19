namespace Calisthenics.Database.Persistence.Entities;

public class ApplicationConfigurationEntity
{
    public int Id { get; set; }
    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
}