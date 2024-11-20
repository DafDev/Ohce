
namespace Daf.Oche.Console;
public class Reversor
{
    public (string actual, bool isActualPallindrome) Reverse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return (string.Empty, false);
        var reversed = string.Join(string.Empty, input.Reverse().ToList()) ?? string.Empty;
        return (reversed, input == reversed);
    }
}
