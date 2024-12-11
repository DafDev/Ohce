using Daf.Oche.Api.Greet;
using Daf.Oche.Domain.Greet;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Time.Testing;
using Moq;

namespace Daf.Oche.Api.Tests.Greet;

public class GreeterEndpointMapperTests
{
    private readonly FakeTimeProvider _timeProvider = new();
    private readonly Mock<IGreet> _greeter = new();
    private readonly GreeterEndpointMapper _sut = new();
    
    [Theory]
    [ClassData(typeof(GreetingsHolaTestData))]
    public async Task GivenTimeOfDayWhenHolaReturnAppropriateGreetings(string name,TimeOnly timeOfDay,string expected)
    {
        //Given
        _timeProvider.SetUtcNow(new DateTimeOffset(new DateOnly(2024, 11, 30), timeOfDay,TimeSpan.Zero));
        _timeProvider.SetLocalTimeZone(TimeZoneInfo.Utc);
        _greeter.Setup(greet => greet.Hola(name, timeOfDay)).ReturnsAsync(expected);
        
        // When
        var actual = await _sut.Hola(name, _greeter.Object, _timeProvider);
        
        // Should
        var result = actual.Result.As<Ok<string>>();
        result.Should().NotBeNull();
        result.Value.Should().Be(expected);
    }
    
    [Theory]
    [ClassData(typeof(GreetingsAdiosTestData))]
    public async Task  GivenNameWhenAdiosShouldReturnProperGreeting(string name, string expected)
    {
        //Given 
        _greeter.Setup(greet => greet.Adios(name)).ReturnsAsync(expected);

        // When
        var actual = await _sut.Adios(name, _greeter.Object);

        // Should
        actual.Value.Should().Be(expected);
    }
}