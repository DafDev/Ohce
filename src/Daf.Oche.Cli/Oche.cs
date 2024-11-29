using Daf.Oche.Domain.Greet;
using Daf.Oche.Domain.ReverseWords;

namespace Daf.Oche.Cli;
public class Oche(IGreet greeter, IReverseWords wordsReversor)
{
    private const string Stop = "Stop!";
    private const string Pallindrome = "Bonita Palabra!";
    public async Task Execute(string name)
    {
        var timeOfDay = TimeOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(await greeter.Hola(name, timeOfDay));
        do
        {
            string word = Console.ReadLine() ?? string.Empty;
            if (word == Stop)
            {
                Console.WriteLine(await greeter.Adios(name));
                break;
            }

            (string reverse, bool isPallindrome) = await wordsReversor.Reverse(word);
            Console.WriteLine(reverse);
            if (isPallindrome)
                Console.WriteLine(Pallindrome);
        } while (true);
    }
}
