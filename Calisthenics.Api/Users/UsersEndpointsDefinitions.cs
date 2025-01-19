using Calisthenics.Api.Infrastructure.Endpoints;
using Calisthenics.Api.Infrastructure.Swagger;
using Calisthenics.Api.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calisthenics.Api.Users;

public class UsersEndpointsDefinitions : IEndpointsDefinitions
{
    public void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", GetUsers).AllowAnonymous()
            .WithTags(SwaggerConsts.Tags.UsersEndpoints).WithGroupName(SwaggerConsts.PublicGroupName);
    }

    private static async Task<IResult> GetUsers([FromServices] IUserService userService,
        CancellationToken cancellationToken = default)
    {
        var users = await userService.GetAllUsers(cancellationToken);
        return Results.Ok(users);
    }
}