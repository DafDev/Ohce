namespace Daf.Oche.Domain.Greet;
public interface IGreet
{
    string Adios(string name);
    string Hola(string name, TimeOnly timeOfDay);
}
