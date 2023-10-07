using System.Text.RegularExpressions;

namespace FastScript.Grammar;

public class Lexer
{
    // private static readonly Regex _tokenRegex = new Regex(@"(?<String>""[^""\\]*(?:\\.[^""\\]*)*"")|(?<Number>\d+)|(?<Identifier>\w+)|(?<Symbol>[^\w\s]+)", RegexOptions.Compiled);
    
    private string SourceCode = "";

    public Lexer(string sourceCode)
    {
        this.SourceCode = sourceCode;
    }

    public List<Token> Run()
    {
        string WordNow = "";
        List<Token> Tokens = new List<Token>();
        string[] Lines = this.SourceCode.Split("\n");
        for (int i = 0; i < Lines.Length; i++)
        {
            for (int j = 0; j < Lines[i].Length; j++)
            {
                char CharNow = Lines[i][j];
                if (TSCharList.TCL.Contains(CharNow.ToString()))
                {
                    if (!TSCharList.SCL.Contains(CharNow.ToString()))
                    {
                        if (WordNow != "")
                        {
                            Token NewToken = new Token();
                            NewToken.Type = Token.GetTokenType(WordNow);
                            NewToken.Name = WordNow;
                            NewToken.LineNumber = i;
                            NewToken.CharNumber = j;
                            Tokens.Add(NewToken);
                            WordNow = "";
                        }
                        Token CharToken = new Token();
                        CharToken.Type = TokenTypes.CHAR;
                        CharToken.Name = CharNow.ToString();
                        CharToken.LineNumber = i;
                        CharToken.CharNumber = j;
                        Tokens.Add(CharToken);
                        continue;
                    }
                    if (WordNow != "")
                    {
                        Token NewToken = new Token();
                        NewToken.Type = Token.GetTokenType(WordNow);
                        NewToken.Name = WordNow;
                        NewToken.LineNumber = i;
                        NewToken.CharNumber = j;
                        Tokens.Add(NewToken);
                        WordNow = "";
                    }
                    
                }

                WordNow += CharNow.ToString();
                continue;
            }

        }

        return Tokens;
    }
}