namespace Daf.Oche.Domain.Greet;
internal class Greeter() : IGreet
{
    public string Adios(string name) => $"Adios {name}";

    public string Hola(string name, TimeOnly timeOfDay)
    {
        var momentOfDay = timeOfDay.Hour switch
        {
            >= 6 and < 12 => "Buenos dias",
            >= 12 and < 20 => "Buenas tardes",
            >= 20 or < 6 => "Buenas noches",
        };
        return $"{momentOfDay} {name}!";
    }
}
