using Microsoft.OpenApi.Models;

namespace Calisthenics.Api.Infrastructure.Swagger;

public static class SwaggerConfigurationInstallationExtensions
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(SwaggerConsts.PublicGroupName, new OpenApiInfo
            {
                Title = "Calisthenics Coach API",
                Version = "v1",
                Description = "API for managing users, workouts, exercises, and progress in a calisthenics coach app."
            });
        });
    }

    public static void UseConfiguredSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint($"/swagger/{SwaggerConsts.PublicGroupName}/swagger.json",
                $"Calisthenics Coach API");
            options.RoutePrefix =
                string.Empty; // This makes Swagger UI accessible at the root URL (http://localhost:5000) //TODO check this
        });
    }
}