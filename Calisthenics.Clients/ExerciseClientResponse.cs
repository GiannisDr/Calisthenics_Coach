using System.Text.Json.Serialization;

namespace Calisthenics.Clients;

public class ExerciseClientResponse
{
    [JsonPropertyName("choices")]
    public List<Choice> Choices { get; set; }
}

public class Choice
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}