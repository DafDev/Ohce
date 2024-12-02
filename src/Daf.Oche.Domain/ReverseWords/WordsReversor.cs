namespace Daf.Oche.Domain.ReverseWords;
internal class WordsReversor : IReverseWords
{
    public async Task<(string actual, bool isActualPallindrome)> Reverse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return (string.Empty, false);
        var reversed = string.Join(string.Empty, input.Reverse().ToList()) ?? string.Empty;
        return await Task.FromResult((reversed, input == reversed));
    }
}
