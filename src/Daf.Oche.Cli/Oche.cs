using Daf.Oche.Domain;

namespace Daf.Oche.Cli;
public class Oche(IGreet greeter, IReverseWords wordsReversor, string name)
{
    private const string STOP = "Stop!";
    private const string PALLINDROME = "Bonita Palabra!";
    public void Execute()
    {
        var timeOfDay = TimeOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(greeter.Hola(name, timeOfDay));
        string word;
        do
        {
            word = Console.ReadLine() ?? string.Empty;
            if (word == STOP)
            {
                Console.WriteLine(greeter.Adios(name));
                break;
            }

            (string reverse, bool isPallindrome) = wordsReversor.Reverse(word);
            Console.WriteLine(reverse);
            if (isPallindrome)
                Console.WriteLine(PALLINDROME);
        } while (true);
    }
}
