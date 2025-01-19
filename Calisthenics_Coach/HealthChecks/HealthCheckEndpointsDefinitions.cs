using Calisthenics_Coach.Infrastructure.Endpoints;
using Calisthenics_Coach.Infrastructure.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Calisthenics_Coach.HealthChecks;

public class HealthCheckEndpointsDefinitions : IEndpointsDefinitions
{
    public void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/health", GetStatus).AllowAnonymous()
            .WithTags(SwaggerConsts.Tags.HealthCheckEndpoints).WithGroupName(SwaggerConsts.PublicGroupName);
        
        app.MapGet("/health/report", GetReport).AllowAnonymous()
            .WithTags(SwaggerConsts.Tags.HealthCheckEndpoints).WithGroupName(SwaggerConsts.PublicGroupName);
    }

    private static async Task<IResult> GetStatus([FromServices] HealthCheckService service,
        CancellationToken cancellationToken = default)
    {
        var report = await service.CheckHealthAsync(cancellationToken);
        var status = report.Status.ToString();

        return report.Status != HealthStatus.Unhealthy
            ? Results.Ok(status)
            : Results.Json(data: status, statusCode: StatusCodes.Status503ServiceUnavailable);
    }
    
    private static async Task<IResult> GetReport([FromServices] HealthCheckService service,
        CancellationToken cancellationToken = default)
    {
        var report = await service.CheckHealthAsync(cancellationToken);
       

        return report.Status != HealthStatus.Unhealthy
            ? Results.Ok(report)
            : Results.Json(data: report, statusCode: StatusCodes.Status503ServiceUnavailable);
    }
}