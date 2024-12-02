using Daf.Oche.Api.ReverseWords;
using Daf.Oche.Api.ReverseWords.Model;
using Daf.Oche.Domain.ReverseWords;
using FluentAssertions;
using Moq;

namespace Daf.Oche.Api.Tests.ReversWords;

public class ReversorEndpointMapperTests
{
    private readonly Mock<IReverseWords> _wordsReversor = new();
    private readonly WordsReversorEndpointMapper _sut = new();
    [Theory]
    [ClassData(typeof(ReversorTestsData))]
    public async Task GivenWordWhenReverseShouldReturnReversedWordAndIfPallindrome(string input, ReversedWord reversedWord)
    {
        // Given
        _wordsReversor.Setup(reversor => reversor.Reverse(input))
            .ReturnsAsync((reversedWord.Text, reversedWord.IsPallindrome));
        
        // When
       var actual = await _sut.Reverse(input, _wordsReversor.Object);

        // Should
        actual.Value.Should().BeEquivalentTo(reversedWord);
    }
}