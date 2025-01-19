using Calisthenics_Coach.Infrastructure.Endpoints;
using Calisthenics_Coach.Infrastructure.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().CreateLogger();

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.AddConsole(); //todo add another logger (like serilog)
});


builder.Services.AddHealthChecks();
builder.Services.ConfigureSwagger();

builder.Services.RegisterEndpoints();
var app = builder.Build();
app.UseConfiguredSwagger();
app.UseRegisteredEndpoints();


//test api
//app.MapGet("/api/hello", () => "Hello, Calisthenics Coach!");


app.Run();