using Daf.Oche.Domain.Greet;
using Daf.Oche.Domain.ReverseWords;
using FluentAssertions;
using Moq;

namespace Daf.Oche.Cli.Tests;
public class OhceTests
{
    private readonly Mock<IGreet> _greeter = new();
    private readonly Mock<IReverseWords> _wordsReversor = new();
    
    [Fact]
    public void GivenPallindromDisplayBuenasPalabras()
    {
        // Given
        const string name = "Marco";
        const string inputs = """
            oto
            Stop!
            """;
        SetupDependencies(name);
        var consoleInput = new StringReader(inputs);
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        Console.SetIn(consoleInput);
        const string expected = """
            Buenas tardes Marco!
            oto
            Bonita Palabra!
            Adios Marco

            """;
        var sut = new Oche(_greeter.Object, _wordsReversor.Object);
        // When
        sut.Execute(name);

        // Should
        consoleOutput.ToString().Should().Be(expected);
    }

    private void SetupDependencies(string name)
    {
        _greeter.Setup(greet => greet.Hola(name, It.IsAny<TimeOnly>())).ReturnsAsync($"Buenas tardes {name}!");
        _greeter.Setup(greet => greet.Adios(name)).ReturnsAsync($"Adios {name}");
        _wordsReversor.Setup(reversor => reversor.Reverse(It.IsAny<string>())).ReturnsAsync(("oto", true));
    }
}
