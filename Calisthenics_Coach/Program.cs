using Calisthenics_Coach.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureSwagger();


var app = builder.Build();
app.UseConfiguredSwagger();


//test api
app.MapGet("/api/hello", () => "Hello, Calisthenics Coach!");


app.Run();