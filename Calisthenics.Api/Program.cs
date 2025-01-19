using Calisthenics.Api.Exercises.Extensions;
using Calisthenics.Api.Infrastructure.Endpoints;
using Calisthenics.Api.Infrastructure.Swagger;
using Calisthenics.Api.Users.Extensions;
using Calisthenics.Clients;
using Calisthenics.Database.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, false)
    .AddEnvironmentVariables();

builder.Configuration
    .AddUserSecrets<Program>()
    .Build();

builder.Services.AddClients(builder.Configuration);

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.AddConsole(); //todo add another logger (like serilog)
});


builder.Services.AddHealthChecks();
builder.Services.ConfigureSwagger();
builder.Services.RegisterEndpoints();

builder.Services.AddCalisthenicsDatabase(builder.Configuration);

builder.Services.AddUserFeature();
builder.Services.AddExerciseFeature();


var app = builder.Build();
app.UseConfiguredSwagger();
app.UseRegisteredEndpoints();


//test api
//app.MapGet("/api/hello", () => "Hello, Calisthenics Coach!");


app.Run();