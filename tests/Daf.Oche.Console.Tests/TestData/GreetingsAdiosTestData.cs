namespace Daf.Oche.Console.Tests.TestData;

internal class GreetingsAdiosTestData : TheoryData<string, string>
{
    public GreetingsAdiosTestData()
    {
        Add("Sarah", "Adios Sarah");
        Add("Guillermo", "Adios Guillermo");
    }
}