namespace Daf.Oche.Api.Endpoints;

public static class EndpointDefinitionExtensions
{
    public static IServiceCollection AddEndpointDefinitions(this IServiceCollection services, params Type[] scanMarkers)
    {
        var endpointDefinitions = new List<IDefineEndpoints>();

        foreach (var scanMarker in scanMarkers)
        {
            endpointDefinitions.AddRange(
                scanMarker.Assembly.ExportedTypes
                    .Where(type => typeof(IDefineEndpoints).IsAssignableFrom(type) && !type.IsInterface)
                    .Select(Activator.CreateInstance).Cast<IDefineEndpoints>()
            );
        }

        services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IDefineEndpoints>);
        return services;
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = app.Services.GetRequiredService<IReadOnlyCollection<IDefineEndpoints>>();

        foreach (var endpointDefinition in endpointDefinitions)
        {
            endpointDefinition.DefineEndpoints(app);
        }
    }
}
