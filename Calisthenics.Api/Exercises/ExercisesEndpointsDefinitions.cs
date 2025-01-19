using Calisthenics.Api.Exercises.Services;
using Calisthenics.Api.Infrastructure.Endpoints;
using Calisthenics.Api.Infrastructure.Swagger;
using Calisthenics.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calisthenics.Api.Exercises;

public class ExercisesEndpointsDefinitions : IEndpointsDefinitions
{
    public void DefineEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/exercises").AllowAnonymous().WithTags(SwaggerConsts.Tags.ExercisesEndpoints)
            .WithGroupName(SwaggerConsts.PublicGroupName);

        group.MapGet("/", GetExercises);
        group.MapPost("/", AddExercise);
        group.MapDelete("/{id:int}", DeleteExercise);
    }
    
    private static async Task<IResult> GetExercises([FromServices] IExerciseService exerciseService,
        CancellationToken cancellationToken = default)
    {
        var exercises = await exerciseService.GetAll(cancellationToken);
        return Results.Ok(exercises);
    }
    
    private static async Task<IResult> AddExercise([FromServices] IExerciseService exerciseService,
        [FromBody]Exercise exercise,
        CancellationToken cancellationToken = default)
    {
        await exerciseService.AddAsync(exercise, cancellationToken);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteExercise([FromServices] IExerciseService exerciseService,
        int id,
        CancellationToken cancellationToken = default)
    {
        await exerciseService.DeleteAsync(id, cancellationToken);
        return Results.Ok();
    }
}