using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calisthenics.Clients;

public static class ClientsInstallationExtensions
{
    public static void AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IExerciseClient, ExerciseClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.deepseek.com/beta");
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", configuration["OpenAIClientApiKey"]);
        });
    }
}