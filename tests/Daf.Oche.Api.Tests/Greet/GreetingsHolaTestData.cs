namespace Daf.Oche.Api.Tests.Greet;
internal class GreetingsHolaTestData : TheoryData<string, TimeOnly, string>
{
    public GreetingsHolaTestData()
    {
        Add("Pedro", new TimeOnly(8, 0), "Buenos dias Pedro!");
        Add("Pedro", new TimeOnly(14, 0), "Buenas tardes Pedro!");
        Add("Sarah", new TimeOnly(22, 0), "Buenas noches Sarah!");
        Add("Max", new TimeOnly(22, 0), "Buenas noches Max!");
    }
}
