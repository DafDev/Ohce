namespace Daf.Oche.Domain.Tests.Greet;

internal class GreetingsAdiosTestData : TheoryData<string, string>
{
    public GreetingsAdiosTestData()
    {
        Add("Sarah", "Adios Sarah");
        Add("Guillermo", "Adios Guillermo");
    }
}