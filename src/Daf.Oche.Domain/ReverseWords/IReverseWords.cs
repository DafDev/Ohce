namespace Daf.Oche.Domain.ReverseWords;

public interface IReverseWords
{
    Task<(string actual, bool isActualPallindrome)> Reverse(string input);
}