using System.Text.Json.Serialization;

namespace Calisthenics.Clients;

public class DeepSeekRequest
{
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }
    [JsonPropertyName("model")] 
    public required string Model { get; set; } 
    
    [JsonPropertyName("max_tokens")]
    public required int MaxTokens { get; set; }
    [JsonPropertyName("stream")]
    public required bool Stream { get; set; }
}