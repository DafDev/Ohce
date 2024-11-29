using Daf.Oche.Domain.ReverseWords;
using Daf.Oche.Domain.Tests.TestData;
using FluentAssertions;

namespace Daf.Oche.Domain.Tests.ReverseWords;
public class WordsReversorTests
{
    private readonly WordsReversor _sut = new();

    [Theory]
    [ClassData(typeof(ReversorTestsData))]
    public async Task GivenWordWhenReverseShouldReturnReversedWordAndIfPallindrome(string input, string expected, bool isExpectedPallindrome)
    {
        // When
        (string actual, bool isActualPallindrome) = await _sut.Reverse(input);

        // Should
        actual.Should().Be(expected);
        isActualPallindrome.Should().Be(isExpectedPallindrome);
    }
}
