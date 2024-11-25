namespace Daf.Oche.Domain;

public interface IReverseWords
{
    (string actual, bool isActualPallindrome) Reverse(string input);
}