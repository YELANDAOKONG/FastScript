namespace FastScript.Grammar.Exceptions;

public class GrammarParsingException : Exception
{
    public GrammarParsingException() : base("A syntax error was found while parsing the code.")
    {
    }
    
    public GrammarParsingException(string message) : base(message)
    {
    }
    
    public GrammarParsingException(string message, Exception inner) : base(message, inner)
    {
    }
    

}