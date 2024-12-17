using Daf.Oche.Api.Endpoints;
using Daf.Oche.Domain.Greet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Daf.Oche.Api.Greet;

public class GreeterEndpointMapper : IDefineEndpoints
{
    private const string Tags = "Greetings";
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/greetings/hola", Hola)
            .WithName(nameof(Hola))
            .WithTags(Tags)
            .WithDescription("Greets you with your name but in Spanish.");
        app.MapGet("/greetings/adios", Adios)
            .WithName(nameof(Adios))
            .WithTags(Tags)
            .WithDescription("Bids you good bye in Spanish.");
    }
    
    public async Task<Results<Ok<string>,NotFound>> Hola([FromQuery]string name, [FromServices] IGreet greeter ,[FromServices] TimeProvider provider)
    {
        if (string.IsNullOrWhiteSpace(name))
            return TypedResults.NotFound();
        
        var results = await greeter.Hola(name, TimeOnly.FromTimeSpan(provider.GetLocalNow().TimeOfDay));
        return TypedResults.Ok(results);
    }

    public async Task<Ok<string>> Adios(string name, [FromServices] IGreet greeter)
    {
        var results = await greeter.Adios(name);
        return TypedResults.Ok(results);
    }
}