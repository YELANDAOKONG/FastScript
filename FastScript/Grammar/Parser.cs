using FastScript.Grammar.Exceptions;

namespace FastScript.Grammar;

public class Parser
{
    List<Token> Tokens = new List<Token>();

    public Parser(List<Token> tokens)
    {
        this.Tokens = tokens;
    }

    public AST Run()
    {
        AST Root = new AST();
        for (int i = 0; i < this.Tokens.Count; i++)
        {
            Token TokenNow = this.Tokens[i];
            if (TokenNow.Type == TokenTypes.CHAR)
            {
                if (Tokens.Count >= i + 1 && this.Tokens[i+1].Type == TokenTypes.ID && this.Tokens[i+1].Name == "encoding")
                {
                    ASTNode astNode = new ASTNode();
                    astNode.Type = "encoding";
                    if (Tokens.Count >= i + 2 && this.Tokens[i+2].Type == TokenTypes.ID)
                    {
                        astNode.Value = this.Tokens[i+2].Name;
                    }
                    else
                    {
                        throw new GrammarParsingException("Encoding must have a value");
                    }
                }
            }
        }

        return Root;
    }
}