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
        var name = "Marco";
        var inputs = """
            oto
            Stop!
            """;
        SetupDependencies(name);
        var consoleInput = new StringReader(inputs);
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        Console.SetIn(consoleInput);
        var expected = """
            Buenas tardes Marco!
            oto
            Bonita Palabra!
            Adios Marco

            """;
        var sut = new Oche(_greeter.Object,_wordsReversor.Object,name);
        // When
        sut.Execute();

        // Should
        consoleOutput.ToString().Should().Be(expected);
    }

    private void SetupDependencies(string name)
    {
        _greeter.Setup(greet => greet.Hola(name, It.IsAny<TimeOnly>())).Returns($"Buenas tardes {name}!");
        _greeter.Setup(greet => greet.Adios(name)).Returns($"Adios {name}");
        _wordsReversor.Setup(reversor => reversor.Reverse(It.IsAny<string>())).Returns(("oto", true));
    }
}
