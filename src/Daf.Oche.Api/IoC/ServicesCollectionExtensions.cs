namespace Daf.Oche.Api.IoC;
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddSingleton<TimeProvider>(TimeProvider.System);
        return services;
    }
}
