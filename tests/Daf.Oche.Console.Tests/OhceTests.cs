using FluentAssertions;

namespace Daf.Oche.Cli.Tests;
public class OhceTests
{
    [Fact]
    public void GivenPallindromDisplayBuenasPalabras()
    {
        // Given
        var inputs = """
            oto
            Stop!
            """;
        var consoleInput = new StringReader(inputs);
        var consoleOutput = new StringWriter();
        System.Console.SetOut(consoleOutput);
        System.Console.SetIn(consoleInput);
        var expected = """
            Buenas tardes Marco!
            oto
            Bonita Palabra!
            Adios Marco

            """;
        var sut = new Oche("Marco");
        // When
        sut.Execute();

        // Should
        consoleOutput.ToString().Should().Be(expected);
    }
}
