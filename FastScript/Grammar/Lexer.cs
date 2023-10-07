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
        bool InString = false;
        bool InComment = false;
        List<Token> Tokens = new List<Token>();
        string[] Lines = this.SourceCode.Split("\n");
        for (int i = 0; i < Lines.Length; i++)
        {
            for (int j = 0; j < Lines[i].Length; j++)
            {
                char CharNow = Lines[i][j];
                if (InString)
                {
                    if (CharNow == '"')
                    {
                        if (j - 1 >= 0)
                        {
                            if (Lines[i][j - 1] != '\\')
                            {
                                InString = false;
                                WordNow += "\"";
                                continue;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (CharNow == '"')
                    {
                        InString = true;
                        WordNow += "\"";
                        continue;
                    }
                }

                if (InString)
                {
                    WordNow += CharNow.ToString();
                    continue;
                }

                if (TSCharList.TCL.Contains(CharNow.ToString().ToLower()))
                {
                    if (!TSCharList.SCL.Contains(CharNow.ToString().ToLower()))
                    {
                        if (WordNow != "")
                        {
                            Token NewToken = new Token();
                            NewToken.Type = Token.GetTokenType(WordNow.ToLower());
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
                        NewToken.Type = Token.GetTokenType(WordNow.ToLower());
                        NewToken.Name = WordNow;
                        NewToken.LineNumber = i;
                        NewToken.CharNumber = j;
                        Tokens.Add(NewToken);
                        WordNow = "";
                    }
                    continue;
                }

                WordNow += CharNow.ToString();
                continue;
            }

        }

        
        return FixSyntaxToken(Tokens);
    }

    private List<Token> FixSyntaxToken(List<Token> Tokens)
    {
        List<Token> TokenList = Tokens;
        for (int i = 0; i < TokenList.Count; i++)
        {
            if (TokenList[i].Name.StartsWith("\"") && !TokenList[i].Name.EndsWith("\""))
            {
                
            }
        }
        return TokenList;
    }
}