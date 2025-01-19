using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Calisthenics.Clients;

public class ExerciseClient : IExerciseClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ExerciseClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    public async Task<ExerciseClientResponse> SendPromptAsync(string prompt)
    {
        var apiKey = _configuration["OpenAIClientApiKey"];
        
        // Define the request payload
        var requestBody = new DeepSeekRequest
        {
            
            Prompt = prompt,
            MaxTokens = 500,
            Model = "deepseek-chat",
            Stream = false
        };

        // Serialize the request to JSON
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Add authorization header
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        // Send the request to DeepSeek API
        var response = await _httpClient.PostAsync("https://api.deepseek.com/beta/v1/completions", content);
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Error Response: " + errorResponse);
            throw new HttpRequestException($"API request failed: {response.StatusCode}");
        }

        // Read and return the response
         var responseAsString =  await response.Content.ReadAsStringAsync();
        
        // Deserialize the JSON response
        return JsonSerializer.Deserialize<ExerciseClientResponse>(responseAsString)!;
    }
}