using System.Text.RegularExpressions;

namespace FastScript.Grammar;

public class Token
{
    public string Name { get; set; }
    public TokenTypes Type { get; set; }
    public int LineNumber { get; set; }
    public int CharNumber { get; set; }


    public static TokenTypes GetTokenType(string name)
    {
        if (TSCharList.TCL.Contains(name))
        {
            return TokenTypes.CHAR;
        }

        foreach (var wobj in RWList.WeightList.Keys)
        {
            if (RWList.RegexList.ContainsKey(RWList.WeightList[wobj]))
            {
                string regex = RWList.RegexList[RWList.WeightList[wobj]];
                if (Regex.Match(name, regex).Length == name.Length)
                {
                    return StringToTokenType(RWList.WeightList[wobj]);
                }
            }
            return TokenTypes.UNKNOW;
        }

        return TokenTypes.UNKNOW;
    }

    public static TokenTypes StringToTokenType(string name)
    {
        TokenTypes TempType = TokenTypes.UNKNOW;
        bool IsSuccess = TokenTypes.TryParse(name, out TempType);
        if (IsSuccess)
        {
            return TempType;
        }

        return TokenTypes.UNKNOW;
    }
}