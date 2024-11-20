namespace Daf.Oche.Console;
public class Oche(string name)
{
    public void Execute()
    {
        var timeOfDay = TimeOnly.FromDateTime(DateTime.Now);
        System.Console.WriteLine(Greetings.Hola(name, timeOfDay));
        string word;
        do
        {
            word = System.Console.ReadLine() ?? string.Empty;
            if (word == "Stop!")
            {
                System.Console.WriteLine(Greetings.Adios(name));
                break;
            }

            (string reverse, bool isPallindrome) = Reversor.Reverse(word);
            System.Console.WriteLine(reverse);
            if (isPallindrome)
                System.Console.WriteLine("Bonita Palabra!");
        } while (true);
    }
}
