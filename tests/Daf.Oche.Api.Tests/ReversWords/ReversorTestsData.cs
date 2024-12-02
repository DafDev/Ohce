namespace Daf.Oche.Api.Tests.ReversWords;
public class ReversorTestsData : TheoryData<string?, string, bool>
{
    public ReversorTestsData()
    {
        Add("",string.Empty,false);
        Add("  ",string.Empty,false);
        Add(null,string.Empty,false);
        Add("hola","aloh",false);
        Add("gracias","saicarg",false);
        Add("oto","oto",true);
        Add("Oto","otO",false);
    }
}
