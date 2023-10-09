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
                // String Part Start
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
                // String Part End

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
        // Foreach Part Start =======================================================================================================
        // POINT_NUMBER FIX -------------------------------------------
        for (int i = 0; i < TokenList.Count; i++)
        {
            Token TokenNow = TokenList[i];
            if (TokenNow.Name.Equals("."))
            {
                if (i + 1 < TokenList.Count)
                {
                    if (Regex.Match(TokenList[i + 1].Name, "^[0-9]+$").Length == TokenList[i + 1].Name.Length)
                    {
                        if (i - 1 >= 0)
                        {
                            if (Regex.Match(TokenList[i - 1].Name, "^[0-9]+$").Length == TokenList[i - 1].Name.Length)
                            {
                                TokenList[i].Type = TokenTypes.POINT_NUMBER;
                                TokenList[i].Name += TokenList[i + 1].Name;
                                TokenList.RemoveAt(i + 1);
                                TokenList[i].Name = TokenList[i - 1].Name + TokenList[i].Name;
                                TokenList.RemoveAt(i - 1);
                            }
                        }
                    }
                }
            }
            
        }
        // Numbers in Scientific notation FIX -------------------------------------------
        for (int i = 0; i < TokenList.Count; i++)
        {
            Token TokenNow = TokenList[i];
            if (TokenNow.Name.Equals("."))
            {
                if (i + 1 < TokenList.Count)
                {
                    if (Regex.Match(TokenList[i + 1].Name, "^[0-9]+e$").Length == TokenList[i + 1].Name.Length)
                    {
                        if (i - 1 >= 0)
                        {
                            if (Regex.Match(TokenList[i - 1].Name, "^[0-9]+$").Length == TokenList[i - 1].Name.Length)
                            {
                                if (i + 2 >= 0)
                                {
                                    if (Regex.Match(TokenList[i + 2].Name, "^[+-]$").Length == TokenList[i + 2].Name.Length)
                                    {
                                        if (i + 3 >= 0)
                                        {
                                            if (Regex.Match(TokenList[i + 3].Name, "^[0-9]+$").Length == TokenList[i + 3].Name.Length)
                                            {
                                
                                                TokenList[i].Type = TokenTypes.NUMBER;
                                                TokenList[i].Name = TokenList[i].Name + TokenList[i + 1].Name + TokenList[i + 2].Name + TokenList[i + 3].Name;
                                                TokenList.RemoveAt(i + 3);
                                                TokenList.RemoveAt(i + 2);
                                                TokenList.RemoveAt(i + 1);
                                                TokenList[i].Name = TokenList[i - 1].Name + TokenList[i].Name;
                                                TokenList.RemoveAt(i - 1);
                                        
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < TokenList.Count; i++)
        {
            Token TokenNow = TokenList[i];
            if (TokenNow.Name.Equals("."))
            {
                if (i + 1 < TokenList.Count)
                { if (Regex.Match(TokenList[i + 1].Name, "^[0-9]+e+[0-9]+$").Length == TokenList[i + 1].Name.Length)
                    {
                        if (i - 1 >= 0)
                        {
                            if (Regex.Match(TokenList[i - 1].Name, "^[0-9]+$").Length == TokenList[i - 1].Name.Length)
                            {
                                TokenList[i].Type = TokenTypes.NUMBER;
                                TokenList[i].Name = TokenList[i].Name + TokenList[i + 1].Name;
                                TokenList.RemoveAt(i + 1);
                                TokenList[i].Name = TokenList[i - 1].Name + TokenList[i].Name;
                                TokenList.RemoveAt(i - 1);
                                                


                            }
                        }
                    }
                }
            }
        }
        // Foreach Part End =======================================================================================================
        return TokenList;
    }
}