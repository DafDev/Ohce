using Daf.Oche.Domain.Greet;
using FluentAssertions;

namespace Daf.Oche.Domain.Tests.Greet;

public class GreeterTest
{
    private readonly Greeter _sut = new();
    [Theory]
    [ClassData(typeof(GreetingsHolaTestData))]
    public async Task GivenNameAndTImeOfDayWhenHolaShouldReturnProperGreeting(string name, TimeOnly timeOfDay, string expected)
    {
        // When
        var actual = await _sut.Hola(name, timeOfDay);

        // Should
        actual.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(GreetingsAdiosTestData))]
    public async Task  GivenNameWhenAdiosShouldReturnProperGreeting(string name, string expected)
    {
        // When
        var actual = await _sut.Adios(name);

        // Should
        actual.Should().Be(expected);
    }
}