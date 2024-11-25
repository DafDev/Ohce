using Daf.Oche.Domain.Greet;
using Daf.Oche.Domain.ReverseWords;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Oche.Domain.IoC;
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IReverseWords, WordsReversor>();
        services.AddTransient<IGreet, Greeter>();
        return services;
    }
}
