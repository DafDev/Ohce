namespace Daf.Oche.Domain.Greet;
public interface IGreet
{
    Task<string> Adios(string name);
    Task<string> Hola(string name, TimeOnly timeOfDay);
}
