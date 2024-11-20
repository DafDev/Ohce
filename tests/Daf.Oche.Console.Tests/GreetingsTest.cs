using Daf.Oche.Console.Tests.TestData;
using FluentAssertions;

namespace Daf.Oche.Console.Tests;

public class GreetingsTest
{
    [Theory]
    [ClassData(typeof(GreetingsHolaTestData))]
    public void GivenNameAndTImeOfDayWhenHolaShouldReturnProperGreeting(string name, TimeOnly timeOfDay, string expected)
    {
        // When
        var actual = Greetings.Hola(name, timeOfDay);

        // Should
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(GreetingsAdiosTestData))]
    public void GivenNameWhelAdiosShouldReturnProperGreeting(string name, string expected)
    {
        // When
        var actual = Greetings.Adios(name);

        // Should
        actual.Should().Be(expected);
    }
}