namespace Daf.Oche.Domain;
public interface IGreet
{
    string Adios(string name);
    string Hola(string name, TimeOnly timeOfDay);
}
