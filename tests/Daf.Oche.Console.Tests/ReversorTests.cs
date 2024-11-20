using Daf.Oche.Console.Tests.TestData;
using FluentAssertions;

namespace Daf.Oche.Console.Tests;
public class ReversorTests
{
    private readonly Reversor _sut = new();

    [Theory]
    [ClassData(typeof(ReversorTestsData))]
    public void GivenWordWhenReverseShouldReturnReversedWordAndIfPallindrome(string input,string expected,bool isExpectedPallindrome)
    {
        // When
        (string actual, bool isActualPallindrome) = _sut.Reverse(input);

        // Should
        actual.Should().Be(expected);
        isActualPallindrome.Should().Be(isExpectedPallindrome);
    }
}
