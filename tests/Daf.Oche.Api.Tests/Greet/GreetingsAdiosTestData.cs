namespace Daf.Oche.Api.Tests.Greet;

internal class GreetingsAdiosTestData : TheoryData<string, string>
{
    public GreetingsAdiosTestData()
    {
        Add("Sarah", "Adios Sarah");
        Add("Guillermo", "Adios Guillermo");
    }
}