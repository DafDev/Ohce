using Daf.Oche.Api.Endpoints;
using Daf.Oche.Api.ReverseWords.Model;
using Daf.Oche.Domain.ReverseWords;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Daf.Oche.Api.ReverseWords;

public class WordsReversorEndpointMapper : IDefineEndpoints
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/reversor/reverse",Reverse)
            .WithName(nameof(Reverse))
            .WithTags("Reversor")
            .WithDescription("Reverses words and detects palindromes");
    }
    
    public async Task<Ok<ReversedWord>> Reverse([FromQuery] string input,[FromServices] IReverseWords reversor)
    {
        (string word, bool isPalindrome) = await reversor.Reverse(input);
        return TypedResults.Ok(new ReversedWord(word, isPalindrome)); 
    }
}