using Daf.Oche.Domain.Tests.TestData;
using FluentAssertions;

namespace Daf.Oche.Domain.Tests;

public class GreeterTest
{
    private readonly Greeter _sut = new();
    [Theory]
    [ClassData(typeof(GreetingsHolaTestData))]
    public void GivenNameAndTImeOfDayWhenHolaShouldReturnProperGreeting(string name, TimeOnly timeOfDay, string expected)
    {
        // When
        var actual = _sut.Hola(name,timeOfDay);

        // Should
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(GreetingsAdiosTestData))]
    public void GivenNameWhelAdiosShouldReturnProperGreeting(string name, string expected)
    {
        // When
        var actual = _sut.Adios(name);

        // Should
        actual.Should().Be(expected);
    }
}