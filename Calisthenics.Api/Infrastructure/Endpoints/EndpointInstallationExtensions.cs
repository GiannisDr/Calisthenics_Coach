namespace Calisthenics.Api.Infrastructure.Endpoints;

public static class EndpointInstallationExtensions
{
    public static void RegisterEndpoints(this IServiceCollection services)
    {
        var endpointsTypes =
            typeof(EndpointInstallationExtensions).Assembly.ExportedTypes.Where(x =>
                    typeof(IEndpointsDefinitions).IsAssignableFrom(x) && x is { IsClass: true, IsAbstract: false })
                .ToList();

        foreach (var endpointsType in endpointsTypes)
        {
            services.AddSingleton<Func<IServiceProvider, IEndpointsDefinitions>>(sp => (IEndpointsDefinitions)ActivatorUtilities.CreateInstance(sp, endpointsType));
        }
    }


    public static IEndpointRouteBuilder UseRegisteredEndpoints(this IEndpointRouteBuilder endpointsRouteBuilder)
    {
        var endpointDefinitionsFactories = endpointsRouteBuilder.ServiceProvider
            .GetRequiredService<IEnumerable<Func<IServiceProvider, IEndpointsDefinitions>>>();

        var endpointsDefinitions =
            endpointDefinitionsFactories.Select(x => x.Invoke(endpointsRouteBuilder.ServiceProvider));

        var logger = endpointsRouteBuilder.ServiceProvider.GetRequiredService<ILogger<Program>>();
        foreach (var endpointDefinition in endpointsDefinitions)
        {
            logger.LogInformation($"Using endpoints from: {endpointDefinition}");
            endpointDefinition.DefineEndpoints(endpointsRouteBuilder);
        }

        return endpointsRouteBuilder;
    }
}