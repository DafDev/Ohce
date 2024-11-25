namespace Daf.Oche.Domain.ReverseWords;

public interface IReverseWords
{
    (string actual, bool isActualPallindrome) Reverse(string input);
}