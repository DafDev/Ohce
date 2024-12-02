using Daf.Oche.Api.Endpoints;
using Daf.Oche.Domain.Greet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Daf.Oche.Api.Greet;

public class GreeterEndpointMapper : IDefineEndpoints
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/greetings/hola", Hola);
        app.MapGet("/greetings/adios", Adios);
    }
    
    public async Task<Ok<string>> Hola([FromQuery]string name, [FromServices] IGreet greeter ,[FromServices] TimeProvider provider)
    {
        var results = await greeter.Hola(name, TimeOnly.FromTimeSpan(provider.GetLocalNow().TimeOfDay));
        return TypedResults.Ok(results);
    }

    public async Task<Ok<string>> Adios(string name, [FromServices] IGreet greeter)
    {
        var results = await greeter.Adios(name);
        return TypedResults.Ok(results);
    }
}