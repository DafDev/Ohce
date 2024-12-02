using Daf.Oche.Api.ReverseWords.Model;

namespace Daf.Oche.Api.Tests.ReversWords;
public class ReversorTestsData : TheoryData<string?, ReversedWord>
{
    public ReversorTestsData()
    {
        Add("",new(string.Empty,false));
        Add("  ",new(string.Empty,false));
        Add(null,new(string.Empty,false));
        Add("hola",new("aloh",false));
        Add("gracias",new("saicarg",false));
        Add("oto",new("oto",true));
        Add("Oto",new("otO",false));
    }
}
